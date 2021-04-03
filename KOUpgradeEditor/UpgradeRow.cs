﻿/**
 * ______________________________________________________
 * This file is part of ko-item-tbl-importer project.
 * 
 * @author       Mustafa Kemal Gılor <mustafagilor@gmail.com> (2015)
 * .
 * SPDX-License-Identifier:	MIT
 * ______________________________________________________
 */

using System;
using System.Collections.Generic;

namespace KOUpgradeEditor
{
    class UpgradeRow : ICloneable
    {
        private const int Npc = 5001;
        List<int> _reqItems = new List<int>();

        public UpgradeRow(int Index = 0, int Modifier = 0, string Name = "", int Cost = 0, string Note = "", int Extension = -1)
        {
            this.Index = Index;
            this.Modifier = Modifier;
            this.Name = Name;
            this.Cost = Cost;
            this.Note = Note;
            this.Extension = Extension;

            for (int i = 0; i < 8; i++)
                _reqItems.Add(0);
        }

        /*
         * nIndex, nNPCNum, strName, strNote, nOriginType, nOriginItem, nReqItem1, nReqItem2, nReqItem3, nReqItem4, nReqItem5, nReqItem6, nReqItem7, 
                      nReqItem8, nReqNoah, bRateType, nGenRate, nGiveItem
         */
        public int Index { get; set; }
        public int nNPCNum { get { return Npc; } }
        public string Name { get; set; }
        public string Note { get; set; }
        public int Extension { get; set; }
        public int Item { get; set; }
        public List<int> RequiredItems { get { return _reqItems; } }
        public int Cost { get; set; }
        public int RateType { get; set; }
        public int Percent { get; set; }
        public int Modifier { get; set; }

        public string toInsert()
        {
            return string.Format("INSERT INTO ITEM_UPGRADE (nIndex, nNPCNum, strName, strNote, nOriginType, nOriginItem, nReqItem1, nReqItem2, nReqItem3, nReqItem4, nReqItem5, nReqItem6, nReqItem7, nReqItem8, nReqNoah, bRateType, nGenRate, nGiveItem) VALUES ({0}, {1}, '{2}', '{3}', {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17})",
                Index, nNPCNum, Name, Note, Extension, Item, RequiredItems[0], RequiredItems[1], RequiredItems[2], RequiredItems[3], RequiredItems[4], RequiredItems[5], RequiredItems[6], RequiredItems[7], Cost, RateType, Percent, Modifier);
        }

        object ICloneable.Clone() { return this.Clone(); }
        public UpgradeRow Clone()
        { 
            UpgradeRow r = (UpgradeRow)this.MemberwiseClone();
            r._reqItems = new List<int>(_reqItems);
            return r;
        }
    }
}
