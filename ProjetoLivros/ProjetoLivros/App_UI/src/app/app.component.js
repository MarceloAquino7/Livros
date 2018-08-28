"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var api_service_1 = require("./api/api.service");
var AppComponent = /** @class */ (function () {
    function AppComponent(api) {
        this.api = api;
    }
    AppComponent.prototype.ngOnInit = function () {
        this.getAllBooks();
    };
    AppComponent.prototype.delete_book = function (book) {
        var _this = this;
        this.api.post("book/delete", book).subscribe(function (data) {
            _this.getAllBooks();
        });
    };
    AppComponent.prototype.getAllBooks = function () {
        var _this = this;
        this.api.get("book/getall").subscribe(function (data) {
            _this.list_books = [];
            _this.list_books = data.json();
        });
    };
    AppComponent.prototype.orderbyname = function () {
        var _this = this;
        this.api.get("book/indexordered").subscribe(function (data) {
            _this.list_books = [];
            _this.list_books = data.json();
        });
    };
    AppComponent.prototype.new_book = function () {
        this.isnew = true;
    };
    AppComponent.prototype.go_back = function () {
        this.isnew = false;
        this.iseditable = false;
        this.showSuccess = false;
    };
    AppComponent.prototype.save_book = function () {
        var _this = this;
        this.api.post("book/create", {
            Name: this.book_name,
            Author: this.author,
            PublisherName: this.publisher,
            Price: parseFloat(this.price.toString())
        }).subscribe(function (data) {
            _this.showSuccess = true;
            _this.getAllBooks();
            setTimeout(function (_) {
                _this.go_back();
            }, 1000);
        });
    };
    AppComponent.prototype.edit = function (book) {
        this.bookId = book.BookId;
        this.book_name = book.Name;
        this.author = book.Author;
        this.price = book.Price;
        this.publisher = book.PublisherName;
        this.iseditable = true;
    };
    AppComponent.prototype.save_edit = function () {
        var _this = this;
        this.api.post("book/update", {
            BookId: this.bookId,
            Name: this.book_name,
            Author: this.author,
            PublisherName: this.publisher,
            Price: parseFloat(this.price.toString())
        }).subscribe(function (data) {
            _this.showSuccess = true;
            _this.getAllBooks();
            setTimeout(function (_) {
                _this.go_back();
            }, 1000);
        });
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'app-root',
            templateUrl: '/App_UI/src/index.html',
            styleUrls: ['./app.component.css']
        }),
        __metadata("design:paramtypes", [api_service_1.ApiService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map