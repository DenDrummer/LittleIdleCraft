using System;
using System.Data.Entity;

namespace LIC
{
    public class MyDbInitializer
        : DropCreateDatabaseIfModelChanges<MyDbContext>
        //: DropCreateDatabaseAlways<MyDbContext>
    {
        private byte currTier;
        private double baseCost;
        private double costMult;
        private double costIncr = 1.05;
        private double multIncr = 1.01;
        private double tierCostMult = 2;
        private double tierCostIncr = 1.5;
        private int id = 1;
        protected override void Seed(MyDbContext ctx)
        {
            currTier = 1;
            baseCost = 1;
            costMult = 1.1;
            costIncr = 1.05;
            multIncr = 1.01;
            tierCostMult = 2;
            tierCostIncr = 1.5;
            id = 1;

            #region Tier 1

            #region Air
            Item air = newItem("Air", true);
            ctx.Items.Add(air);

            Crafter airCrafter = newCrafter(air, researched: true);
            ctx.Crafters.Add(airCrafter);
            #endregion Air

            NextId();

            #region Earth

            Item earth = newItem("Earth", true);
            ctx.Items.Add(earth);
            
            Crafter earthCrafter = newCrafter(earth, researched: true);
            ctx.Crafters.Add(earthCrafter);
            #endregion Earth

            NextId();

            #region Fire
            Item fire = newItem("Fire", true);
            ctx.Items.Add(fire);

            Crafter fireCrafter = newCrafter(fire, researched: true);
            ctx.Crafters.Add(fireCrafter);
            #endregion Fire

            NextId();

            #region Water
            Item water = newItem("Water", true);
            ctx.Items.Add(water);

            Crafter waterCrafter = newCrafter(water, researched: true);
            ctx.Crafters.Add(waterCrafter);
            #endregion Water

            #endregion Tier 1

            NextTier();

            #region Tier 2

            #region Energy
            Item energy = newItem("Energy");
            ctx.Items.Add(energy);

            Crafter energyCrafter = newCrafter(energy, mom: air, dad: fire);
            ctx.Crafters.Add(energyCrafter);
            #endregion Energy

            NextId();

            #region Lava
            Item lava = newItem("Lava");
            ctx.Items.Add(lava);

            Crafter lavaCrafter = newCrafter(lava, mom: earth, dad: fire);
            ctx.Crafters.Add(lavaCrafter);
            #endregion Lava

            NextId();

            #region Steam
            Item steam = newItem("Steam");
            ctx.Items.Add(steam);

            Crafter steamCrafter = newCrafter(steam, mom: fire, dad: water);
            ctx.Crafters.Add(steamCrafter);
            #endregion Steam

            #endregion Tier 2

            NextTier();

            #region Tier 3

            #region Stone
            Item stone = newItem("Stone");
            ctx.Items.Add(stone);

            Crafter stoneCrafter = newCrafter(stone, mom: air, dad: lava);
            ctx.Crafters.Add(stoneCrafter);
            #endregion Stone

            #endregion Tier 3

            NextTier();

            #region Tier 4

            #region Metal
            Item metal = newItem("Metal");
            ctx.Items.Add(metal);

            Crafter metalCrafter = newCrafter(metal, mom: fire, dad: stone);
            ctx.Crafters.Add(metalCrafter);
            #endregion Metal

            #endregion Tier 4

            ctx.SaveChanges();
        }

        private void NextTier()
        {
            baseCost *= costIncr * costIncr;
            costMult *= multIncr * multIncr;
            id++;
            currTier++;
        }

        private void NextId()
        {
            baseCost *= costIncr;
            costMult *= multIncr;
            id++;
        }

        private Item newItem(string name, bool researched = false)
        {
            return new Item()
            {
                Id = id,
                Name = name,
                BaseWorth = currTier + id * 0.1,
                Count = 0,
                Tier = currTier,
                Researched = researched
            };
        }

        private Crafter newCrafter(Item kid,Item mom=null,byte momsNeeded=1,Item dad=null,byte dadsNeeded = 1, byte kidsMade=1,bool researched=false)
        {
            if (mom != null)
            {
                if (dad != null)
                {
                    return new Crafter()
                    {
                        Id = id,
                        Mom = mom,
                        MomsNeeded = momsNeeded,
                        Dad = dad,
                        DadsNeeded = dadsNeeded,
                        Kid = kid,
                        KidsMade = kidsMade,
                        BaseCost = baseCost * Math.Pow(costIncr, id - 1) * Math.Pow(tierCostMult, currTier - 1),
                        CostMultiplier = costMult * Math.Pow(multIncr, id - 1) * Math.Pow(tierCostIncr, currTier - 1),
                        Level = 0,
                        Researched = researched
                    };
                }
                else
                {
                    return new Crafter()
                    {
                        Id = id,
                        Mom = mom,
                        MomsNeeded = momsNeeded,
                        Kid = kid,
                        KidsMade = kidsMade,
                        BaseCost = baseCost * Math.Pow(costIncr, id - 1) * Math.Pow(tierCostMult, currTier - 1),
                        CostMultiplier = costMult * Math.Pow(multIncr, id - 1) * Math.Pow(tierCostIncr, currTier - 1),
                        Level = 0,
                        Researched = researched
                    };
                }
            }
            else
            {
                //starter items
                return new Crafter()
                {
                    Id = id,
                    Mom = mom,
                    Kid = kid,
                    KidsMade = kidsMade,
                    BaseCost = baseCost * Math.Pow(costIncr, id - 1) * Math.Pow(tierCostMult, currTier - 1),
                    CostMultiplier = costMult * Math.Pow(multIncr, id - 1) * Math.Pow(tierCostIncr, currTier - 1),
                    Level = 0,
                    Researched = researched
                };
            }
        }
    }
}