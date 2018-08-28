import { Component, OnInit } from '@angular/core';
import { ApiService } from './api/api.service';

@Component({
    selector: 'app-root',
    templateUrl: '/App_UI/src/index.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent {
    bookId: number;
    book_name: string;
    author: string;
    publisher: string;
    price: number;
    isnew: boolean;
    iseditable: boolean;
    list_books: any;
    showSuccess: boolean;

    constructor(private api: ApiService) { }

    ngOnInit(): void {
        this.getAllBooks();
    }

    delete_book(book) {
        this.api.post("book/delete", book).subscribe(data => {
            this.getAllBooks();
        });
    }

    getAllBooks() {
        this.api.get("book/getall").subscribe(data => {
            this.list_books = [];
            this.list_books = data.json();
        });
    }

    orderbyname() {
        this.api.get("book/indexordered").subscribe(data => {
            this.list_books = [];
            this.list_books = data.json();
        });
    }

    new_book() {
        this.isnew = true;
    }

    go_back() {
        this.isnew = false;
        this.iseditable = false;
        this.showSuccess = false;
    }

    save_book() {
        this.api.post("book/create", {
            Name: this.book_name,
            Author: this.author,
            PublisherName: this.publisher,
            Price: parseFloat(this.price.toString())
        }).subscribe(data => {
            this.showSuccess = true;
            this.getAllBooks();
            setTimeout(_ => {
                this.go_back();
            }, 1000);
        });
    }

    edit(book) {
        this.bookId = book.BookId;
        this.book_name = book.Name;
        this.author = book.Author;
        this.price = book.Price;
        this.publisher = book.PublisherName;
        this.iseditable = true;
    }

    save_edit() {
        this.api.post("book/update", {
            BookId: this.bookId,
            Name: this.book_name,
            Author: this.author,
            PublisherName: this.publisher,
            Price: parseFloat(this.price.toString())
        }).subscribe(data => {
            this.showSuccess = true;
            this.getAllBooks();
            setTimeout(_ => {
                this.go_back();
            }, 1000);
        });
    }
}  