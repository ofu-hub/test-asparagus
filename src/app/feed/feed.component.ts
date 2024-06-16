import { Component, OnInit } from '@angular/core';
import { AsparagusService } from '../asparagus.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-feed',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './feed.component.html',
  styleUrl: './feed.component.css'
})
export class FeedComponent implements OnInit {
  entries: any[] = [];

  constructor(private asparagusService: AsparagusService, private router: Router) { }

  ngOnInit(): void {
    this.asparagusService.getEntries().subscribe(data => {
      this.entries = data;
    });
  }

  navigateToForm() {
    this.router.navigate(['/form']);
  }
}
