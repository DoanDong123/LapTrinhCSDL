import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import * as $ from 'jquery';

declare var google:any;

@Component({
  selector: 'app-cau5-de5',
  templateUrl: './cau5-de5.component.html',
  styleUrls: ['./cau5-de5.component.css']
})
export class Cau5De5Component implements OnInit {

  dsHangHoa: any = {};

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { }

  ngOnInit() {
  }

  submit (){
    var begin = $('#beginDate').val();
    var end = $('#endDate').val();
    var x : any = {
      ngayBatDau: begin,
      ngayKetThuc: end
    }

    this.http.post('https://localhost:44377/' + 'api/DoanQuiDong/SoLuongHangHoaTrongKhoangThoiGian_Linq', x).subscribe(result => {
      var res: any = result;
      this.dsHangHoa = res.data;
      
    }, error => console.error(error));
  }

  

}
