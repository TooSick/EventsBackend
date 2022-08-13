using AutoMapper;
using EventsApplication.Common.Mappings;
using EventsDomain.Entities;

namespace EventsApplication.Queries.GetEventList
{
    public class EventLookupDto : IMapWith<Event>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public string Venue { get; set; }
        public string Sponsor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventLookupDto>()
                .ForMember(eventDto => eventDto.Id,
                    opt => opt.MapFrom(ev => ev.Id))
                .ForMember(eventDto => eventDto.Venue,
                    opt => opt.MapFrom(ev => ev.Venue))
                .ForMember(eventDto => eventDto.Time,
                    opt => opt.MapFrom(ev => ev.Time))
                .ForMember(eventDto => eventDto.Description,
                    opt => opt.MapFrom(ev => ev.Description))
                .ForMember(eventDto => eventDto.Sponsor,
                    opt => opt.MapFrom(ev => ev.Sponsor));
        }
    }
}
