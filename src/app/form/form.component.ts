import { Component } from '@angular/core';
import { AsparagusService } from '../asparagus.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})

export class FormComponent {
  name: string = '';
  email: string = '';

  constructor(private asparagusService: AsparagusService, private router: Router) { }

  onSubmit() {
    const entry = { name: this.name, email: this.email };
    this.asparagusService.addEntry(entry).subscribe(response => {
      console.log(entry);
    });
  }
  
  navigateToFeed() {
    this.router.navigate(['/feed']);
  }
}
