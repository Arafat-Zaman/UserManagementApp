import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = 'https://localhost:7038/api/Users'; // Users API
  private dataSourceUrl = 'https://localhost:7038/api/datasource'; // DataSource API

  constructor(private http: HttpClient) { }

  // Get all users
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl);
  }

  // Get a user by ID
  getUserById(id: number): Observable<User> {
    return this.http.get<User>(`${this.baseUrl}/${id}`);
  }

  // Add a new user
  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.baseUrl, user);
  }

  // Update an existing user
  updateUser(user: User): Observable<void> {
    return this.http.put<void>(this.baseUrl, user);
  }

  // Delete a user
  deleteUser(id: number): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/${id}`);
  }

  // Update the data source
  updateDataSource(dataSource: string): Observable<void> {
    return this.http.post<void>(this.dataSourceUrl, JSON.stringify(dataSource), {
      headers: { 'Content-Type': 'application/json' },
    });
  }

  // Search users by query
  searchUsers(query: string): Observable<User[]> {
    const url = `${this.baseUrl}/search?query=${encodeURIComponent(query)}`;
    return this.http.get<User[]>(url);
  }
}
