using Acme.BookStore.Authors;
using Acme.BookStore.EntityFrameworkCore;
using Xunit;

namespace Acme.BookStore.Books;

[Collection(BookStoreTestConsts.CollectionDefinitionName)]
public class BookAppService_Tests : BookAppService_Tests<BookStoreEntityFrameworkCoreTestModule>
{
}