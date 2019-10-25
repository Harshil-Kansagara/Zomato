import { Component, OnInit, OnDestroy } from "@angular/core";
import { Review } from '../../../model/review';
import { ReviewService } from '../../../service/review.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import * as jwt_decode from 'jwt-decode';
import { ToastrService } from 'ngx-toastr';
import { CommentService } from '../../../service/comment.service';
import { Comment } from '../../../model/comment';

@Component({
  templateUrl: './review-restaurant.component.html',
  styleUrls: ['./review-restaurant.component.css']
})

export class ReviewComponent implements OnInit, OnDestroy {
  review: Review;
  comment: Comment;
  reviewList: Review[] = [];
  restaurantName: string;
  promise: Subscription;
  token: string;
  decode_token: string;
  userId: string;
  isShow: boolean = false;

  constructor(private reviewService: ReviewService, private router: Router,
    private toastr: ToastrService, private commentService: CommentService) { }

  ngOnInit(): void{
    this.restaurantName = this.router.url.split('/')[2];
    this.review = this.reviewService.initializeReview();
    this.comment = this.commentService.initializeComment();
    this.loadReviewList();
  }

  ngOnDestroy() {
    this.promise.unsubscribe();
  }

  checkUserStatus() {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      console.log("Token is not null: ", this.token);
      this.decode_token = jwt_decode(this.token)
      this.userId = this.decode_token['UserId'];
      console.log(this.userId);
       return true;
    } else {
      this.toastr.error("Please login first");
      return false;
    }
  }

  loadReviewList(): void {
    this.promise = this.reviewService.getReviewList(this.restaurantName).subscribe(
      res => {
        if (res != null) {
          this.reviewList = res as Review[];
          console.log(this.reviewList);
        }
      }, err => {
        console.log(err);
      }
    );
  }

  addReview() {
    if (this.checkUserStatus()) {
      this.review.userId = this.userId;
      console.log(this.review);
      this.promise = this.reviewService.addNewReview(this.restaurantName, this.review).subscribe(
        res => {
          this.loadReviewList();
        }, err => {
          console.log(err);
        });
    }
  }

  addComment(reviewId: number) {
    if (this.checkUserStatus()) {
      this.comment.reviewId = reviewId;
      this.comment.userId = this.userId;
      this.promise = this.commentService.addComment(this.comment).subscribe(
        res => {
          this.loadComment(reviewId);
        }, err => {
          console.log(err);
        }
      );
    }
  }

  loadComment(reviewId: number) {
    this.promise = this.commentService.getCommentList(reviewId).subscribe(
      res => {
        if (res != null) {
          console.log(res);
        }
      }, err => {
        console.log(err);
      }
    );
  }

  toggleComment(reviewId:number): void {
    this.isShow = !this.isShow;
    this.loadComment(reviewId);
  }
}
