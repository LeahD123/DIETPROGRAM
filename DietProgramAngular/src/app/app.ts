import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  //יבוא הקומפוננטות הממומשות בדף הHTML פה
  imports: [RouterOutlet,RouterLink],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App implements OnInit{
  ngOnInit(): void {
  }
  protected title = 'DietProgram';
}
