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
  apiUrl = 'https://localhost:7038/api/datasource'; // Backend API URL

  constructor(private http: HttpClient) { }

  // Lifecycle hook to fetch the current data source on component initialization
  ngOnInit(): void {
    this.fetchCurrentDataSource();
  }

  // Fetch the current data source from the server
  fetchCurrentDataSource(): void {
    this.http.get<{ currentDataSource: string }>(this.apiUrl).subscribe({
      next: (response) => {
        this.selectedSource = response.currentDataSource;
        console.log(`Fetched current data source: ${this.selectedSource}`);
      },
      error: (err) => console.error('Error fetching current data source:', err),
    });
  }

  // Update the data source on the server
  onDataSourceChange(): void {
    const body = JSON.stringify(this.selectedSource); // Send data as JSON
    const headers = { 'Content-Type': 'application/json' }; // Set the Content-Type header

    this.http.post(this.apiUrl, body, { headers, responseType: 'text' }).subscribe({
      next: () => console.log(`Data source updated to ${this.selectedSource}`),
      error: (err) => console.error('Error updating data source:', err),
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


