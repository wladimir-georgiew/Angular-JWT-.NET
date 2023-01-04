import { Component, OnInit } from '@angular/core';
import { StandService } from './stand.service';

@Component({
  selector: 'app-stand',
  templateUrl: './stand.component.html',
  styleUrls: ['./stand.component.css']
})
export class StandComponent implements OnInit {
  public stands: [] = [];
  constructor(private standService: StandService) { }

  ngOnInit(): void {
      this.getStands();
  }

  public getStands() {
    this.standService.GetStands('stands/all')
      .subscribe(res => {
        this.stands = res as [];
      })
  }
}
