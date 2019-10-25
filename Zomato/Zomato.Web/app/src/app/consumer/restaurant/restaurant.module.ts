import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { MatSidenavModule, MatButtonModule, MatInputModule, MatFormFieldModule, MatCardModule, MatGridListModule, MatCheckboxModule, MatDialogModule, MatRadioModule, MatTabsModule } from '@angular/material';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Debuger } from '../../service/debug.service';
import { ListRestaurantUserComponent } from './list/list-restaurant-user.component';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { NgxPaginationModule } from 'ngx-pagination';
import { DetailRestaurantUserComponent, addUserAddressDialogComponent } from './detail/detail-restaurant-user.component';
import { MenuComponent } from './menu/menu-restaurant.component';
import { ReviewComponent } from './review/review-restaurant.component';
import { BarRatingModule } from "ngx-bar-rating";

const routes: Routes = [
  { path: '', component: ListRestaurantUserComponent },
  {
    path: ':restaurantName', component: DetailRestaurantUserComponent,
    children: [
      { path: '', redirectTo: 'menu', pathMatch: 'full' },
      { path: 'menu', component: MenuComponent },
      { path: 'review', component: ReviewComponent }
    ]
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule,
    HttpClientModule,
    Ng2SearchPipeModule,
    NgxPaginationModule,
    MatSidenavModule, MatButtonModule, MatInputModule, MatFormFieldModule,
    MatCardModule, MatGridListModule, MatCheckboxModule, MatDialogModule,
    MatRadioModule, MatTabsModule,
    BarRatingModule,
    ToastrModule.forRoot({
      progressBar: true
    })
  ],
  declarations: [
    ListRestaurantUserComponent,
    DetailRestaurantUserComponent,
    addUserAddressDialogComponent,
    MenuComponent,
    ReviewComponent
  ],
  providers: [Debuger],
  entryComponents: [addUserAddressDialogComponent]
})
export class RestaurantUserModule {}
