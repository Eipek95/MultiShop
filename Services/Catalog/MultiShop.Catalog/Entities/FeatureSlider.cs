using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MultiShop.Catalog.Entities
{
    public class FeatureSlider
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]//benzersiz
        public string FeatureSliderID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public bool Status { get; set; }
    }
}
