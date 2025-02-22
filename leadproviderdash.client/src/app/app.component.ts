import { Component, OnInit } from '@angular/core';
import { Lead } from './interfaces/lead';
import { LeadService } from './services/lead.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public leads: Lead[] = [];
  public dataFetched: boolean = false;
  public errorMessage: string = '';

  constructor(private leadService: LeadService) {}

  ngOnInit() {
    this.getLeads();
  }

  getLeads() {
    this.leadService.getLeads().subscribe(
      (result) => {
        this.leads = result;
        this.dataFetched = true;
      },
      (error) => {
        
        this.dataFetched = true;
        this.errorMessage = error;
      }
    );
  }

  title = 'leadproviderdash.client';
}
