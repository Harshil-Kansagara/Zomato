import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { Debuger } from '../service/debug.service';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MatInputModule, MatFormFieldModule, MatButtonModule, MatCheckboxModule, MatTableModule, MatPaginatorModule, MatSortModule, MatIconModule, MatCardModule, MatTabsModule, MatDividerModule, MatDialogModule, MatSelectModule, MatOptionModule } from '@angular/material';
import { ListRestaurantComponent } from './restaurant/list/list-restaurant.component';
import { AuthGuard } from '../auth/auth.guard';
import { AuthInterceptor } from '../auth/auth.interceptor';
import { AddRestaurantComponent } from './restaurant/add-restaurant/add-restaurant.component';
import { AddRestaurantInfoComponent } from './restaurant/add-restaurant/add-restaurant-info.component';
import { AddRestaurantSearchComponent } from './restaurant/add-restaurant/add-restaurant-search.component';
import { RestaurantResolver } from '../service/restaurant-resolver.service';
import { AddMenuComponent } from './restaurant/add-menu/add-menu.component';
import { DetailRestaurantComponent } from './restaurant/detail/detail-restaurant.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'restaurant',
    canActivate: [AuthGuard],
    component: ListRestaurantComponent,
  },
  {
    path: 'restaurant/create',
    canActivate: [AuthGuard],
    component: AddRestaurantComponent,
    resolve: { resolvedData: RestaurantResolver },
    children: [
      { path: '', redirectTo: 'info', pathMatch: 'full' },
      { path: 'info', component: AddRestaurantInfoComponent },
      { path: 'search', component: AddRestaurantSearchComponent }
    ]
  },
  {
    path: 'restaurant/:restaurantName',
    canActivate: [AuthGuard],
    component: DetailRestaurantComponent
  },
  {
    path: 'restaurant/:restaurantName/add-menu',
    canActivate: [AuthGuard],
    component: AddMenuComponent
  }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    HttpClientModule,
    FormsModule,
    MatInputModule, MatFormFieldModule, MatButtonModule, MatCheckboxModule, MatTabsModule,
    MatTableModule, MatPaginatorModule, MatSortModule, MatIconModule, MatCardModule,
    MatDividerModule, MatDialogModule, MatSelectModule, MatOptionModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      progressBar: true
    })
  ],
  declarations: [
    LoginComponent,
    RegisterComponent,
    ListRestaurantComponent,
    AddRestaurantComponent,
    AddRestaurantInfoComponent,
    AddRestaurantSearchComponent,
    DetailRestaurantComponent,
    AddMenuComponent
  ],
  providers: [Debuger, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }]
})

export class AdminModule {

}
