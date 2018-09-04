import { Component, OnInit } from '@angular/core';
import { FileService } from '../../services/file.service';
import { FileModel } from '../../models/fileModel';
import EXIF = require('exif-js');

@Component({
  selector: 'main-component',
  templateUrl: './main.html',
  styleUrls: ['./main.css']
})
export class MainComponent implements OnInit {
  currentCount = 0;
  newImgSrc: string = "";

  constructor(private fileService: FileService) { }

  ngOnInit() {
    this.fileService.loadImages();
  }

  incrementCounter() {
    this.currentCount++;
  }

  getExif() {
    console.log('getExif');
    var img1 = document.getElementById("newImg");
    EXIF.getData(img1, function () {
      var make = EXIF.getTag(this, "GPSLongitude");
      var model = EXIF.getTag(this, "GPSLatitude");
      var makeAndModel = document.getElementById("result");
      makeAndModel.innerHTML = `${make} ${model}`;
    });

    var img2 = document.getElementById("newImg");
    EXIF.getData(img2, function () {
      var allMetaData = EXIF.getAllTags(this);
      var allMetaDataSpan = document.getElementById("result1");
      allMetaDataSpan.innerHTML = JSON.stringify(allMetaData, null, "\t");
    });
  }

  onFileChange(event) {
    let reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        console.log(file);
        this.newImgSrc = 'data:image/gif;base64,' + reader.result.split(',')[1];
        setTimeout(() => { this.getExif() }, 1000);

        var fileModel = new FileModel();
        fileModel.name = file.name;
        fileModel.exif = "";
        fileModel.gps = "";
        fileModel.type = "";
        fileModel.value = reader.result.split(',')[1];
        this.fileService.uploadImg(fileModel);
      };
    }

  }
}
