import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  standalone: false,
})
export class HeaderComponent {
  title = 'User Management App';
  selectedSource = 'JSON'; // Default selection
  data: any;

  constructor(private http: HttpClient) { }

  // Fetch data from the selected data source
  onDataSourceChange(): void {
    // Update the data source on the server
    this.http.post('/api/datasource', this.selectedSource, { responseType: 'text' }).subscribe({
      next: () => {
        console.log(`Data source updated to ${this.selectedSource}`);

        // Fetch data from the newly selected data source
        this.http.get(`/api/data?source=${this.selectedSource}`).subscribe({
          next: (response) => (this.data = response),
          error: (err) => console.error('Error fetching data:', err),
        });
      },
      error: (err) => console.error('Error updating data source:', err),
    });
  }
}
