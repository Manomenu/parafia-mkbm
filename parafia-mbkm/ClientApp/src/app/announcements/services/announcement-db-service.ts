this.route.params.subscribe(params => console.log("params : ", params));
http.get<Announcement[]>(baseUrl + 'api/announcement').subscribe({
  next: (result) => {
    this.announcements = result;
    console.log(result);
  }, error: (err) => {
    console.error(err);
  }
});
