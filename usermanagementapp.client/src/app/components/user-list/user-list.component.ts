import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css'],
  standalone: false,
})
export class UserListComponent implements OnInit {
  users: User[] = [];
  selectedSource: string = 'SQL'; // Default data source

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  // Load users based on the selected data source
  loadUsers(): void {
    this.userService.getUsers().subscribe({
      next: (data) => (this.users = data),
      error: (err) => console.error('Error loading users:', err),
    });
  }

  // Update the data source and refresh the user list
  onDataSourceChange(source: string): void {
    this.selectedSource = source;
    this.userService.updateDataSource(source).subscribe({
      next: () => this.loadUsers(),
      error: (err) => console.error('Error updating data source:', err),
    });
  }

  // Delete a user and refresh the list
  deleteUser(id: number): void {
    this.userService.deleteUser(id).subscribe({
      next: () => this.loadUsers(),
      error: (err) => console.error('Error deleting user:', err),
    });
  }
}
