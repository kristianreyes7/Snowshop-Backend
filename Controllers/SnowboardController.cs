using SnowShop.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;//for the route and http attr
using System.Linq;//for the IEnumerable interface

namespace SnowShop.Controllers
{
    [Route("snowboards")]//controller for the /snowboards
    public class SnowboardController{
        //prop to hold db context
        private readonly SnowboardContext snowboards;

        //constr to receive db context via DI
        public SnowboardController(SnowboardContext snowboardsCtx){
            snowboards = snowboardsCtx;
        }

        [HttpGet] //get request to /snowboards
        public IEnumerable<Snowboard> index(){
            //return all the turtles
            return snowboards.Snowboards.ToList();
        }
        [HttpPost] //post request to /snowboards
        public IEnumerable<Snowboard> Post([FromBody] Snowboard Snowboard){
            //add 
            snowboards.Snowboards.Add(Snowboard);
            //save
            snowboards.SaveChanges();
            //return
            return snowboards.Snowboards.ToList(); 
        }
        [HttpGet("{id}")]
        public Snowboard show(long id){
            //return the snowboard based on id
            return snowboards.Snowboards.FirstOrDefault(x => x.id == id);
        }
        [HttpPut("{id}")]
        public IEnumerable<Snowboard> update([FromBody]Snowboard Snowboard, long id){
            //retrieve item to be updated
            Snowboard oldSnowboard = snowboards.Snowboards.FirstOrDefault(
                x => x.id == id
            );
            //update props
            oldSnowboard.company = Snowboard.company;
            oldSnowboard.name = Snowboard.name;
            oldSnowboard.price = Snowboard.price;
            oldSnowboard.description = Snowboard.description;
            oldSnowboard.url = Snowboard.url;
            oldSnowboard.quantity = Snowboard.quantity;
            //save
            snowboards.SaveChanges();
            //return list of snowboards
            return snowboards.Snowboards.ToList();
        }
        [HttpDelete("{id}")]//delete 
        public IEnumerable<Snowboard> destroy(long id){
            //retrieve 
            Snowboard oldSnowboard = snowboards.Snowboards.FirstOrDefault(
                x => x.id == id
            );
            //remove
            snowboards.Snowboards.Remove(oldSnowboard);
            //save
            snowboards.SaveChanges();
            //return 
            return snowboards.Snowboards.ToList();
        }
    }
}