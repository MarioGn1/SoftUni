namespace VaporStore
{
	using AutoMapper;
    using VaporStore.Data.Models;
    using VaporStore.DataProcessor.Dto.Import;

    public class VaporStoreProfile : Profile
	{
		// Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
		public VaporStoreProfile()
		{
			//this.CreateMap<GameDevGenreTagsImportDTO, Game>()
			//	.ForMember(g => g.Developer, x => x.MapFrom(dto => dto.Developer))
			//	.ForMember(g => g.Genre, x => x.MapFrom(dto => dto.Genre))
			//	.ForMember(g => g.GameTags, x => x.MapFrom(dto => dto.Tags))
		}
	}
}