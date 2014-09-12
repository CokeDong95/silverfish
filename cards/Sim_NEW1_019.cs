using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_NEW1_019 : SimTemplate //knifejuggler
    {

        //    fügt einem zufälligen feind 1 schaden zu, nachdem ihr einen diener herbeigerufen habt.
        public override void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            if (triggerEffectMinion.entitiyID != summonedMinion.entitiyID && triggerEffectMinion.own == summonedMinion.own)
            {
                List<Minion> temp = (triggerEffectMinion.own) ? p.enemyMinions : p.ownMinions;

                if (temp.Count >= 1)
                {
                    //search Minion with lowest hp
                    Minion enemy = temp[0];
                    int minhp = 10000;
                    bool found = false;
                    foreach (Minion m in temp)
                    {
                        if (m.name == CardDB.cardName.nerubianegg && enemy.Hp >= 2) continue; //dont attack nerubianegg!

                        if (m.Hp >= 1 && minhp > m.Hp)
                        {
                            enemy = m;
                            minhp = m.Hp;
                            found = true;
                        }
                    }

                    if (found)
                    {
                        p.minionGetDamageOrHeal(enemy, 1);
                    }
                    else
                    {
                        if (triggerEffectMinion.own)
                            p.minionGetDamageOrHeal(p.enemyHero, 1);
                        else
                            p.minionGetDamageOrHeal(p.ownHero, 1);
                    }

                }
                else
                {
                    if (triggerEffectMinion.own)
                        p.minionGetDamageOrHeal(p.enemyHero, 1);
                    else
                        p.minionGetDamageOrHeal(p.ownHero, 1);
                }

                triggerEffectMinion.stealth = false;
            }
        }

    }


}