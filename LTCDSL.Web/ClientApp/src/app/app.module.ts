import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { GoogleChartsModule } from 'angular-google-charts';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { OrderComponent } from './order/order.component';
import { OrderdetailComponent } from './orderdetail/orderdetail.component';
import { ProductsComponent } from './products/products.component';
import { SoluongDonHangKhoangThoiGianComponent } from './soluong-don-hang-khoang-thoi-gian/soluong-don-hang-khoang-thoi-gian.component';
import { ShipperComponent } from './shipper/shipper.component'; 

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    OrderComponent, 
    OrderdetailComponent, ProductsComponent, SoluongDonHangKhoangThoiGianComponent,
    ShipperComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    GoogleChartsModule,
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'order', component: OrderComponent },
      { path: 'orderdetail', component: OrderdetailComponent},
      { path: 'soluong-don-hang-khoang-thoi-gian', component: SoluongDonHangKhoangThoiGianComponent},
      { path: 'orderdetail', component: OrderdetailComponent},
      { path: 'shipper', component: ShipperComponent}

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
