import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as $ from 'jquery';

@Component({
  selector: 'app-soluong-don-hang-khoang-thoi-gian',
  templateUrl: './soluong-don-hang-khoang-thoi-gian.component.html',
  styleUrls: ['./soluong-don-hang-khoang-thoi-gian.component.css']
})
export class SoluongDonHangKhoangThoiGianComponent implements OnInit {

  dsHangHoa: any = {};

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    
  }


  ngOnInit() {
  }

  submit (){
    var begin = $('#beginDate').val();
    var end = $('#endDate').val();
    var x : any = {
      ngayBatDau: begin,
      ngayKetThuc: end
    }

    this.http.post('https://localhost:44377/api/Orders/SoLuongHangHoaTrongKhoangThoiGian_Linq', x).subscribe(result => {
      var res: any = result;
      this.dsHangHoa = res.data;
    }, error => console.error(error));
  }
}
