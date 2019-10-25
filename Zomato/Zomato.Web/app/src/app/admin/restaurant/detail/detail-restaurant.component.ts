 import { Component, OnInit, Inject, ViewChild, AfterViewInit, OnDestroy } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { MenuService } from '../../../service/menu.service';
import { Menu } from '../../../model/menu';
import { Subscription } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { RestaurantService } from '../../../service/restaurant.service';
import { Category } from '../../../model/category';

@Component({
  templateUrl: './detail-restaurant.component.html',
  styleUrls: ['./detail-restaurant.component.css']
})

export class DetailRestaurantComponent implements OnInit, AfterViewInit, OnDestroy {
  pageTitle = "Detail";
  restaurantName: string;
  restaurantDetail: any;
  menuList: string[];
  category: string = '';
  location: string = '';
  menu: Menu[];
  promise: Subscription;
  displayedColumns: string[] = ['ItemName', 'ItemPrice', 'ItemId'];
  dataSource = new MatTableDataSource<Menu>();

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;

  tabLoadTimes: number;

  constructor(private menuService: MenuService, private restaurantService: RestaurantService, private activiateRoute: ActivatedRoute) {
    this.activiateRoute.params.subscribe(params => {
      this.restaurantName = params.restaurantName;
    });
    this.restaurantName = this.restaurantName.replace('-', ' ');
  }

  ngOnInit(): void {
    this.restaurantDetail = this.restaurantService.getRestaurantDetail(this.restaurantName).subscribe(
      res => {
        if (res != null) {
          this.restaurantDetail = res;
          for (let each of this.restaurantDetail['restaurantLocation']) {
            this.location = this.location.concat(each['location']+", ")
          }
          for (let each of this.restaurantDetail['categoryCollection']) {
            this.category = this.category.concat(each['categoryName'] + ", ")
          }
          this.category = this.category.substring(0, this.category.length - 2);
          this.location = this.location.substring(0, this.location.length - 2);
          console.log("Location", this.location);
          console.log("Category", this.category);
          console.log(this.restaurantDetail);
        }
      }, err => {
        console.log(err);
      }
    );
    this.getMenuList();
  }

  ngOnDestroy(): void {
    this.promise.unsubscribe();
  }
  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  doFilter(value: string) {
    this.dataSource.filter = value.trim().toLocaleLowerCase();
  }

  getMenuList(): void {
    this.promise = this.menuService.getMenuList(this.restaurantName).subscribe(
      res => {
        if (res != null) {
          this.menuList = res as string[];
          this.menu = [];
          for (let item of this.menuList) {
            let data = {} as Menu;
            data.ItemId = item['itemId'];
            data.ItemName = item['itemName'];
            data.ItemPrice = item['itemPrice'];
            this.menu.push(data);
          }
          console.log("Menu",this.menu);
          this.dataSource.data = this.menu as Menu[];
        }
      }, err => {
        console.log(err);
      }
    );
  }

  getTimeLoaded1() {
    return 'Harshil';
  }

  getTimeLoaded2() {
    return 'HK';
  }

  getTimeLoaded3() {
    return 'HKK';
  }
}

