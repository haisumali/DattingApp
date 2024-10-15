import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router'; // Import Router here

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './not-found.component.html',
  styleUrls: ['./not-found.component.css'] // Corrected to styleUrls
})
export class NotFoundComponent {
  error: any;

}
