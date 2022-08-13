using EventsApplication.Common.Mappings;
using EventsDomain.Entities;
using AutoMapper;

namespace EventsApplication.Queries.GetEventById
{
    public class EventByIdVm : IMapWith<Event>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public DateTime Time { get; set; }
        public string Venue { get; set; }
        public string Speaker { get; set; }
        public string Sponsor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventByIdVm>()
                .ForMember(eventVm => eventVm.Id,
                    opt => opt.MapFrom(e => e.Id))
                .ForMember(eventVm => eventVm.Title,
                    opt => opt.MapFrom(e => e.Title))
                .ForMember(eventVm => eventVm.Time,
                    opt => opt.MapFrom(e => e.Time))
                .ForMember(eventVm => eventVm.Description,
                    opt => opt.MapFrom(e => e.Description))
                .ForMember(eventVm => eventVm.Plan,
                    opt => opt.MapFrom(e => e.Plan))
                .ForMember(eventVm => eventVm.Venue,
                    opt => opt.MapFrom(e => e.Venue))
                .ForMember(eventVm => eventVm.Speaker,
                    opt => opt.MapFrom(e => e.Speaker))
                .ForMember(eventVm => eventVm.Sponsor,
                    opt => opt.MapFrom(e => e.Sponsor));
        }
    }
}
