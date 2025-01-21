import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  standalone: false,
})

export class HeaderComponent implements OnInit {
  title = 'User Management App';
  selectedSource = 'JSON'; // Default selection
  data: any[] = []; // Store the fetched data
  apiUrl = 'https://localhost:7038/api';

  constructor(private http: HttpClient) { }

  // Lifecycle hook to load data from the current data source
  ngOnInit(): void {
    this.loadData();
  }

  // Update the data source on the server and reload data
  onDataSourceChange(): void {
    const body = JSON.stringify(this.selectedSource);
    const headers = { 'Content-Type': 'application/json' };

    // Update the data source on the server
    this.http.post(`${this.apiUrl}/datasource`, body, { headers }).subscribe({
      next: () => {
        console.log(`Data source updated to ${this.selectedSource}`);
        this.loadData(); // Reload data after updating the source
      },
      error: (err) => console.error('Error updating data source:', err),
    });
  }

  // Fetch data from the selected data source
  loadData(): void {
    this.http.get<any[]>(`${this.apiUrl}/users`).subscribe({
      next: (response) => {
        this.data = response;
        console.log('Fetched data:', this.data);
      },
      error: (err) => console.error('Error fetching data:', err),
    });
  }
}


//export class HeaderComponent {
//  title = 'User Management App';
//  selectedSource = 'JSON'; // Default selection

//  constructor(private http: HttpClient) { }

//  // Update the data source on the server
//  onDataSourceChange(): void {
//    this.http.post('/api/datasource', this.selectedSource, { responseType: 'text' }).subscribe({
//      next: () => console.log(`Data source updated to ${this.selectedSource}`),
//      error: (err) => console.error('Error updating data source:', err),
//    });
//  }
//}

//export class HeaderComponent {
//  title = 'User Management App';
//  selectedSource = 'JSON'; // Default selection
//  data: any;

//  constructor(private http: HttpClient) { }

//  // Fetch data from the selected data source
//  onDataSourceChange(): void {
//    // Update the data source on the server
//    this.http.post('/api/datasource', this.selectedSource, { responseType: 'text' }).subscribe({
//      next: () => {
//        console.log(`Data source updated to ${this.selectedSource}`);

//        // Fetch data from the newly selected data source
//        this.http.get(`/api/data?source=${this.selectedSource}`).subscribe({
//          next: (response) => (this.data = response),
//          error: (err) => console.error('Error fetching data:', err),
//        });
//      },
//      error: (err) => console.error('Error updating data source:', err),
//    });
//  }
//}


