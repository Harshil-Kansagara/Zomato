import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { Debuger } from '../service/debug.service';
import { MatButtonModule, MatInputModule, MatFormFieldModule, MatCardModule, MatGridListModule, MatSidenavModule } from '@angular/material';
import { RestaurantComponent } from './restaurant/restaurant.component';

const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  { path: 'home', redirectTo: '', pathMatch: 'full' },
  { path: 'restaurant', component: RestaurantComponent, loadChildren: 'src/app/consumer/restaurant/restaurant.module#RestaurantUserModule' }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    FormsModule, 
    HttpClientModule,
    MatSidenavModule, MatButtonModule, MatInputModule, MatFormFieldModule,
    MatCardModule, MatGridListModule,
    ToastrModule.forRoot({
      progressBar: true
    })
  ],
  declarations: [
    HomeComponent,
    RestaurantComponent
  ],
  providers:[Debuger]
})

export class ConsumerModule {}
