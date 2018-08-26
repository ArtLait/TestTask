import { Component, Input } from '@angular/core';
import { FileService } from '../../services/file.service';

@Component({
  selector: 'map',
  styles: [`
    agm-map {
      height: 300px;
    }
  `],
  template: `<div>
    <div>Latitude: <span>{{latitude}}</span></div>
    <div>Longtitude: <span>{{longtitude}}</span></div>
    <agm-map [latitude]="longtitude" [longitude]="longtitude"></agm-map>
  </div>
  `
})
export class MapComponent {

  @Input() latitude: number;
  @Input() longtitude: number;
  constructor(private fileService: FileService) {}
}
