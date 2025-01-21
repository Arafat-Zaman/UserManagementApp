import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css'],
  standalone: false,
})

export class UserDetailsComponent implements OnInit {
  user: User | null = null;
  isEditing: boolean = false; // Edit mode state

  constructor(
    private userService: UserService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.userService.getUserById(id).subscribe({
        next: (data) => (this.user = data),
        error: (err) => console.error('Error fetching user details:', err),
      });
    }
  }

  // Enable edit mode
  enableEdit(): void {
    this.isEditing = true;
  }

  // Save changes to the user
  saveChanges(): void {
    if (this.user) {
      this.userService.updateUser(this.user).subscribe({
        next: () => {
          this.isEditing = false; // Exit edit mode
          console.log('User updated successfully.');
        },
        error: (err) => console.error('Error updating user:', err),
      });
    }
  }

  // Cancel edit mode
  cancelEdit(): void {
    this.isEditing = false;
    // Reload the user details to discard unsaved changes
    this.ngOnInit();
  }

  // Navigate back to the user list
  goBack(): void {
    this.router.navigate(['/users']);
  }
}
