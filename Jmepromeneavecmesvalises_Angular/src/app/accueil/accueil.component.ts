import {Component, OnInit} from '@angular/core';
import {HttpService} from "../http.service";
import {Voyage} from "../Voyage";

@Component({
  selector: 'app-accueil',
  templateUrl: './accueil.component.html',
  styleUrls: ['./accueil.component.scss']
})
export class AccueilComponent implements OnInit {
  voyages:Voyage[] = [];

  constructor(public http: HttpService) {
  }

  async ngOnInit(): Promise<void> {
    this.voyages = await this.http.GetAllVoyages();
  }
}
