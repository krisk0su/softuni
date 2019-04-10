class BookCollection {
  constructor(shelfGenre, room, shelfCapacity) {
    if (room === "livingRoom" || room === "bedRoom" || room === "closet") {
      this.shelfGenre = shelfGenre;
      this.room = room;
      this.shelfCapacity = shelfCapacity;
      this.shelf = [];
    } else {
      throw `Cannot have book shelf in ${room}`;
    }
  }

  addBook(bookName, bookAuthor, genre) {
    let book = {};
    book["bookName"] = bookName;
    book["bookAuthor"] = bookAuthor;
    if (genre) {
      book["genre"] = genre;
    }

    if (this.shelf.length < this.shelfCapacity) {
      this.shelf.push(book);
    } else {
      this.shelf.shift();
      this.shelf.push(book);
    }

    this.shelf.sort(function(b1, b2) {
      return b1.bookAuthor > b2.bookAuthor;
    });
  }
  throwAwayBook(bookName) {
    let index = this.shelf.find(function(book) {
      return book.bookName == bookName;
    });

    this.shelf.splice(index, 1);
  }
  showBooks(genre) {
    let newCollection = this.shelf.filter(function(book) {
      if (book.genre) {
        return book.genre == genre;
      }
    });

    let result = `Results for search "${genre}":` + "\n";

    for (const index in newCollection) {
      if (index !== newCollection.length - 1) {
        result +=
          `\uD83D\uDCD6 ${newCollection[index].bookAuthor} - "${
            newCollection[index].bookName
          }"` + "\n";
      } else {
        result += `\uD83D\uDCD6 ${newCollection[index].bookAuthor} - "${
          newCollection[index].bookName
        }"`;
      }
    }

    return result;
  }
  get shelfCondition() {
    return +this.shelfCapacity - +this.shelf.length;
  }

  toString() {
    let result = "";
    if (this.shelf.length === 0) {
      return "It's an empty shelf";
    }
    result += `"${this.shelfGenre}" shelf in ${this.room} contains:\n`;

    for (const book of this.shelf) {
      result += `\uD83D\uDCD6 "${book.bookName}" - ${book.bookAuthor}\n`;
    }

    return result;
  }
}
