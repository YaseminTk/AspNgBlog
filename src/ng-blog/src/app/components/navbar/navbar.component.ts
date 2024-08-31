import { Component, inject } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component'
import { AuthService } from '../../services/auth.service'
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'navbar',
  standalone: true,
  imports: [MatIconModule, MatButtonModule, MatMenuModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  public dialog: MatDialog = inject(MatDialog);
  public authService: AuthService = inject(AuthService);
  dialogConfig: MatDialogConfig = {
    width: "30vw",
    height: "40vh"
  }

  async toggleAuth() {
    if (this.authService.isLogedIn)
      await this.authService.logoutAsync();
    else
      this.dialog.open(LoginComponent, this.dialogConfig);
  }

  openSettings() {
    
  }
}