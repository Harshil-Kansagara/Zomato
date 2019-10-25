import { Component, OnInit, OnDestroy } from "@angular/core";
import { MenuService } from '../../../service/menu.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { Menu } from '../../../model/menu';

@Component({
  templateUrl: './menu-restaurant.component.html',
  styleUrls: ['./menu-restaurant.component.css']
})

export class MenuComponent implements OnInit, OnDestroy {

  menuList: any[];
  promise: Subscription;
  restaurantName: string;
  orderItem: Menu[] = [];

  constructor(private menuService: MenuService, private router: Router) {
  }

  ngOnInit(): void {
    this.restaurantName = this.router.url.split('/')[2];
    this.promise = this.menuService.getMenuList(this.restaurantName).subscribe(
      res => {
        if (res != null) {
          this.menuList = res as any[];
          console.log(this.menuList);
        }
      }, err => {
        console.log(err);
      }
    );
  }

  ngOnDestroy(): void {
    this.promise.unsubscribe();
  }

  addItemToOrder(itemId: number) {
    this.menuList.forEach(each => {
      each.menus.forEach(menu => {
        if (menu.itemId == itemId) {
          console.log(menu);
          this.orderItem.push(menu);
        }
      });
    });
    console.log(this.orderItem);
  }
}
