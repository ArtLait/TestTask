import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { FileService } from '../../services/file.service';
import { FileModel } from '../../models/fileModel';
import EXIF = require('exif-js');

@Component({
  selector: 'pictures-component',
  templateUrl: './pictures.component.html',
  styleUrls: ['./pictures.component.less']
})
export class PicturesComponent implements OnInit {
  currentImg: FileModel = new FileModel();
  previousImg: FileModel = new FileModel();
  latitude: number;
  longtitude: number;
  description = {
    ExifVersion: '',
    Model: '',
    DateTime: '',
    ExposureTime: ''
  };
  isUpload: boolean = false;

  constructor(private fileService: FileService, private cdr: ChangeDetectorRef) { }

  ngOnInit() {
    this.fileService.loadImages();
    this.currentImg.value = "";
  }

  selectImage(item: FileModel) {
    this.isUpload = false;
    this.previousImg = this.currentImg;
    this.currentImg = Object.assign({}, item);
    this.latitude = JSON.parse(item.gps).latitude;
    this.longtitude = JSON.parse(item.gps).longtitude;
    this.description = JSON.parse(item.exif);
  }

  getExif(callback: Function) {
    let img = document.getElementById("newImg");
    let that = this;
    EXIF.getData(img, function () {
      that.latitude = EXIF.getTag(this, "GPSLongitude") ? EXIF.getTag(this, "GPSLongitude")[0].numerator : undefined;
      that.longtitude = EXIF.getTag(this, "GPSLatitude") ? EXIF.getTag(this, "GPSLatitude")[0].numerator : undefined;
      var allMetaData = EXIF.getAllTags(this);
      console.log('allMetaData');
      that.description = {
        ExifVersion: allMetaData.ExifVersion ? allMetaData.ExifVersion : '',
        Model: allMetaData.Model ? allMetaData.Model : '',
        DateTime: allMetaData.DateTime ? allMetaData.DateTime : '',
        ExposureTime: allMetaData.ExposureTime ? allMetaData.ExposureTime : ''
      };
      let gps = {
        latitude: that.latitude,
        longtitude: that.longtitude
      };
      callback(JSON.stringify(allMetaData), JSON.stringify(gps));
    });
  }

  onFileChange(event) {
    let reader = new FileReader();
    if (event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.currentImg.value = reader.result.split(',')[1];
        setTimeout(() => { this.createNewFileModel(file, reader.result.split(',')[1]); }, 1000);        
      };
    }
  }

  upload() {
    this.fileService.uploadImg(this.currentImg);
  }

  preview() {
    this.currentImg = this.previousImg;
  }

  createNewFileModel(file: any, fileValue: string) {
    this.isUpload = true;
    this.getExif((exif: string, gps: string) => {
      this.currentImg.name = file.name;
      this.currentImg.exif = exif;
      this.currentImg.gps = gps;
      this.currentImg.type = file.type;
    });
  }
}
