using AutoMapper;
using Moq;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.BL.Services;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Models;

namespace PlaylistShare.Tests
{
    public class PlaylistServiceTest
    {
        public Mock<ISongRepository> _songRepository;
        public Mock<IPlaylistService> _playlistService;
        public Mock<IMapper> _mapper;

        private IList<Song> Songs = new List<Song>()
        {
        new Song()
        {
            Id = new Guid(),
            Title = "Title",
            Album = "Album",
            Author = "Author",
            PlaylistId = new Guid(),
        },
        new Song()
        {
            Id= new Guid(),
            Title = "Title2",
            Album = "Album2",
            Author = "Author2",
            PlaylistId = new Guid(),
        }
        };

        private IList<Playlist> Playlists = new List<Playlist>()
        {
            new Playlist()
            {
                Id = new Guid(),
                Name = "PlaylistTitle",
                Description = "Description",
            },
        };

        public PlaylistServiceTest()
        {
            _playlistService = new Mock<IPlaylistService>();
            _songRepository = new Mock<ISongRepository>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task Get_All_Songs_Check()
        {
            //setup
            var expectedCount = Songs.Count();

            _songRepository.Setup(x => x.GetAll()).Returns(async () => Songs.AsEnumerable());

            //inject
            var service = new SongService(_songRepository.Object, _mapper.Object);

            //Act
            var result = await service.GetAll();

            //Assert
            var songs = result.ToList();
            Assert.NotNull(songs);
            Assert.Equal(expectedCount, songs.Count);
            Assert.Equal(Songs, songs);
        }

        [Fact]
        public async Task GetById_Song_Ok()
        {
            //setup
            var songId = new Guid();
            var expectedSong = Songs.First(x => x.Id == songId);
            var expectedTitle = expectedSong.Title;

            _songRepository.Setup(x => x.GetById(songId)).Returns(async () => Songs.FirstOrDefault(x => x.Id == songId));

            //inject
            var service = new SongService(_songRepository.Object, _mapper.Object);

            //Act
            var result = await service.GetById(songId);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedSong, result);
        }

        [Fact]
        public async Task GetById_Song_NotFound()
        {
            //setup
            var songId = new Guid("33c6561f-f579-4e7a-a7cc-76ea6c5cf44e");

            _songRepository.Setup(x => x.GetById(songId)).Returns(async () => Songs.FirstOrDefault(x => x.Id == songId));
            //inject
            var service = new SongService(_songRepository.Object, _mapper.Object);

            //Act
            var result = await service.GetById(songId);

            //Assert
            Assert.Null(result);
        }

        //[Fact]
        //public async Task Song_Add_Ok()
        //{
        //    //setup

        //    var songToAdd = new Song
        //    {
        //        Id = new Guid(),
        //        Title = "Title",
        //        Album = "Album",
        //        Author = "Author",
        //        PlaylistId = new Guid(),
        //    };

        //    var expectedSongCount = 3;

        //    _playlistService.Setup(a => a.GetById(songToAdd.PlaylistId)).Returns(() => Task.FromResult(Songs.FirstOrDefault()));

        //    _songRepository.Setup(x => x.GetAllByPlaylistId(songToAdd.PlaylistId)).Returns(() => Task.FromResult(Songs.Where(x => x.PlaylistId == songToAdd.PlaylistId)));

        //    _songRepository.Setup(x => x.Add(It.IsAny<Song>())).Callback(() =>
        //    {
        //        Songs.Add(songToAdd);
        //    }).Returns(Task.CompletedTask);

        //    //inject
        //    var service = new SongService(_songRepository.Object, _mapper.Object);

        //    //Act
        //    await service.Add(songToAdd);

        //    //Assert
        //    Assert.Equal(expectedSongCount, Songs.Count);
        //    Assert.Equal(songToAdd, Songs.LastOrDefault());
        //}

        //[Fact]
        //public async Task Song_Add_Playlist_NotFound()
        //{
        //    //setup

        //    var songToAdd = new Song
        //    {
        //        Id = new Guid("278c446b-0825-44c5-ba92-e83fb707a40e"),
        //        Title = "New Title",
        //        PlaylistId = new Guid("5e74a8ee-9578-4352-9ab4-f93ec3f2373a"),
        //    };

        //    var expectedSongCount = 2;

        //    _playlistService.Setup(a => a.GetById(songToAdd.PlaylistId)).Returns(() => Task.FromResult(Songs.FirstOrDefault(x => x.Id == songToAdd.PlaylistId)));

        //    _songRepository.Setup(x => x.GetAllByPlaylistId(songToAdd.PlaylistId)).Returns(() => Task.FromResult(Songs.Where(x => x.PlaylistId == songToAdd.PlaylistId)));

        //    _songRepository.Setup(x => x.Add(It.IsAny<Song>()));

        //    //inject
        //    var service = new SongService(_songRepository.Object, _mapper.Object);

        //    //Act
        //    var result = await service.Add(songToAdd);

        //    //Assert
        //    Assert.Equal(expectedSongCount, Songs.Count);
        //    Assert.Null(result);
        //}
    }
}