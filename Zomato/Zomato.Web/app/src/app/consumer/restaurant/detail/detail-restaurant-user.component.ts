import { Component, OnInit, OnDestroy, Inject, ViewChild } from "@angular/core";
import { RestaurantService } from '../../../service/restaurant.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Restaurant } from '../../../model/restaurant';
import { Subscription } from 'rxjs';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatSidenav } from '@angular/material';
import { UserAddress } from '../../../model/userAddress';
import { UserAddressService } from '../../../service/user-address.service';
import { ToastrService } from 'ngx-toastr';
import * as jwt_decode from 'jwt-decode';

@Component({
  templateUrl: './detail-restaurant-user.component.html',
  styleUrls: ['./detail-restaurant-user.component.css']
})

export class DetailRestaurantUserComponent implements OnInit, OnDestroy {
  restaurantName: string;
  restaurantDetail: Restaurant;
  promise: Subscription;
  cuisine: string = '';
  location: string = '';
  token: string;
  decode_token: string;
  userId: string;
  addressList: UserAddress[];
  navLinks: any[];
  activeLinkIndex = -1;

  constructor(private router: Router, private restaurantService: RestaurantService, public dialog: MatDialog,
    private activiateRoute: ActivatedRoute, private toastr: ToastrService,
    private userAddressService: UserAddressService) {

    this.activiateRoute.params.subscribe(params => {
      this.restaurantName = params.restaurantName;
    });
    this.restaurantName = this.restaurantName.replace('-', ' ');
    this.navLinks = [
      {
        label: 'Menu',
        link: './menu',
        index: 0
      }, {
        label: 'Review',
        link: './review',
        index: 1
      }
    ]
  }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    if (this.token != null) {
      this.decode_token = jwt_decode(this.token)
      this.userId = this.decode_token['UserId'];
    }
    this.router.events.subscribe((res) => {
      this.activeLinkIndex = this.navLinks.indexOf(this.navLinks.find(tab => tab.link === '.' + this.router.url));
    });
    this.restaurantDetail = this.restaurantService.initializeRestaurant();
    this.restaurantData();
    this.addressDataList();
  }

  restaurantData(): void {
    this.promise = this.restaurantService.getRestaurantDetail(this.restaurantName).subscribe(
      res => {
        if (res != null) {
          this.restaurantDetail = res as Restaurant;
        }
      }, err => {
        console.log(err);
      }
    );
  }

  addressDataList(): void {
    this.promise = this.userAddressService.getUserAddressList(this.userId).subscribe(
      res => {
        if (res != null) {
          this.addressList = res as UserAddress[];
        }
      }, err => {
        console.log(err);
      }
    );
  }

  checkUserLogin(): void {
    if (this.token != null) {
      this.openAddDialog();
    }
    else {
      console.log("Token is null");
      this.toastr.error("Please Login first !");
    }
  }

  addAddress(addressName: string) {
    console.log(addressName);
  }

  ngOnDestroy(): void {
    this.promise.unsubscribe();
  }

  openAddDialog(): void {
    const dialogRef = this.dialog.open(addUserAddressDialogComponent, {
      width: '250px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result != null) {
        result.UserId = this.userId;
        console.log(result);
        this.promise = this.userAddressService.addUserAddress(result).subscribe(
          res => {
              this.addressDataList();
          }, err => {
            if (err.status == 400) {
              this.toastr.error("Location Already exists");
            } else {
              console.log(err);
            }
          }
        );
      }
    });
  }
}

@Component({
  templateUrl: 'dialog-add-location.component.html'
})

export class addUserAddressDialogComponent{

  constructor(private dialogRef: MatDialogRef<addUserAddressDialogComponent>, @Inject(MAT_DIALOG_DATA) public data: UserAddress,
    private addressService: UserAddressService) {
    this.data = this.addressService.initializeUserAddress();
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
