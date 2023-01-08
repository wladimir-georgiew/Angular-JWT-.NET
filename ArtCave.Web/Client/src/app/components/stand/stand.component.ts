import { Component, OnInit } from '@angular/core';
import { RequestHandlerService } from 'src/app/services/request-handler.service';

@Component({
  selector: 'app-stand',
  templateUrl: './stand.component.html',
  styleUrls: ['./stand.component.css']
})
export class StandComponent implements OnInit {
  public stands: string[] = [];
  constructor(private requestHandlerService: RequestHandlerService) { }

  ngOnInit(): void {
      this.getStands();
  }

  public getStands() {
    this.requestHandlerService.HttpGet('stands/all')
      .subscribe(res => {
        this.stands = res as string[];
      })
  }
}
