using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Libraly.BLL.Models.BookDTO;
using Libraly_Test2;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Extensions.Ordering;

namespace Libraly.TestUnit.BookController
{
    public class TestBook:IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly CustomWebApplicationFactory<Startup> _factory;


        private readonly BookViewModel _book = new BookViewModel()
        {
            Id=99999,
            YearBook = Convert.ToDateTime("2017.12.17"),
            AuthorOfBook = "Some Author",
            Count = 2,
            Genres="Thriller",
            LittleDescription = "Some Description",
            LongDescription = "SOOOOME LOOOONG description",
            NameOfBook = "Some Name",
            PhotoUrl = "too some PhotoURL"
        };
        public TestBook(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Fact,Order(1)]
        public async Task CreateBook()
        {
            var json = JsonConvert.SerializeObject(_book);
            //конвертация объекта в JSON
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            //Создание контента
            var response = await _factory.Client.PostAsync("/BookC/CreateBook",content);
            //запрос
            var responseBody = await response.Content.ReadAsStringAsync();
            //прочтения запроса
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jObject = JsonConvert.DeserializeObject(responseBody);
                //из JSON в Object
                var token = JObject.Parse(jObject.ToString() );
                //преобразование в JObject
                var isMoreNull=token["Message"];
               
                //получение книг
                var isTrue = isMoreNull.ToString()== "succeeded" ? true : false;
                Assert.True(isTrue);
            }
        }
        
        [Fact,Order(2)]
        public async Task GetBooks()
        {
            var response = await _factory.Client.GetAsync("/BookC/GetBooks");
            //запрос
            var responseBody = await response.Content.ReadAsStringAsync();
            //прочтения запроса
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jObject = JsonConvert.DeserializeObject(responseBody);
                //из JSON в Object
                var token = JObject.Parse(jObject.ToString() );
                //преобразование в JObject
                var isMoreNull=token["Item"];
               
                //получение книг
                var isTrue = isMoreNull.Any();
                Assert.True(isTrue);
            }
          //  return null;
        }

        [Fact,Order(3)]
        public async Task FindBook()
        {
           var response = await _factory.Client.GetAsync($"/BookC/FindBook/{_book.Id}");
            //запрос
            var responseBody = await response.Content.ReadAsStringAsync();
            //прочтения запроса
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jObject = JsonConvert.DeserializeObject(responseBody);
                //из JSON в Object
                var token = JObject.Parse(jObject.ToString() );
                //преобразование в JObject
                var isMoreNull=token["Item"];
               
                //получение книг
                var isTrue = isMoreNull.Any();
                Assert.True(isTrue);
            }
        }

        [Fact,Order(4)]
        public async Task UpdateBook()
        {
            _book.NameOfBook = "newName";
            var json = JsonConvert.SerializeObject(_book);
            
            var content = new StringContent(json,Encoding.UTF8,"application/json");
            
            var response = await _factory.Client.PostAsync("/BookC/BookUpdate", content);
            var responseFind = await _factory.Client.GetAsync($"/BookC/FindBook/{_book.Id}");
            
            var responseBody = await response.Content.ReadAsStringAsync();
            var responseBodyFind = await responseFind.Content.ReadAsStringAsync();
            if (response.StatusCode == HttpStatusCode.OK && responseFind.StatusCode == HttpStatusCode.OK)
            {
                var jObject = JsonConvert.DeserializeObject(responseBody);
                var jObjectFind = JsonConvert.DeserializeObject(responseBodyFind);
                
                var token = JObject.Parse(jObject.ToString());
                var tokenFind = JObject.Parse(jObjectFind.ToString());
                
                var message = token["Message"];
                var jTokenFind = tokenFind["Item"];

                var book = jTokenFind.ToObject<BookViewModel>();
                
                Assert.Equal(_book.NameOfBook,book.NameOfBook);
                
            }
        }
        
        [Fact,Order(5)]
        public async Task DeleteBook()
        {
            var response = await _factory.Client.DeleteAsync($"/BookC/DeleteBook/{_book.Id}");
            //запрос
            var responseBody = await response.Content.ReadAsStringAsync();
            //прочтения запроса
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jObject = JsonConvert.DeserializeObject(responseBody);
                //из JSON в Object
                var token = JObject.Parse(jObject.ToString() );
                //преобразование в JObject
                var jToken=token["Item"];
                var bookObject = jToken.ToObject<BookViewModel>();
                //получение книг
                
                Assert.Equal(_book.Id,bookObject.Id);
            }
        }
    }
}