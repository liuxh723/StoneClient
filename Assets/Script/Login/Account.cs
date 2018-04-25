namespace KBEngine
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public class Account : AccountBase {
      
        public override void __init__()
        {
            base.__init__();
            Debug.LogFormat("账号初始化成功：{0}",Name);
            KBEngine.Event.fireOut("onLoginSuccessfully");
        }

        public override void onNameChanged(string oldValue)
        {
             Debug.LogFormat("角色名称更改：{0}", oldValue);
            KBEngine.Event.fireOut("Set_Name", Name);
        }
        public override void onGoldChanged(Int32 oldValue)
        {
            Debug.LogFormat("金币更改：{0}", oldValue);
            KBEngine.Event.fireOut("Set_Gold", Gold);
        }
        public override void onKabaoChanged(Int32 oldValue)
        {
            Debug.LogFormat("卡包更改：{0}", oldValue);
            KBEngine.Event.fireOut("Set_Kabao", Kabao);
        }
        public override void onLevelChanged(Int16 oldValue)
        {
        }
        public override void onCardListChanged(CARD_LIST oldValue)
        {
            Debug.LogFormat("卡牌更改：{0}", CardList.Count);
            KBEngine.Event.fireOut("Set_CardList", CardList);
        }
        public override void onOpenPack(OPEN_PACK_RUL arg1)
        {
            KBEngine.Event.fireOut("onOpenPack", arg1);
        }

        public override void onCardGroupListChanged(CARDGROUP_INFO_LIST oldValue)
        {
            Debug.LogFormat("卡组更改：{0}", oldValue);
            KBEngine.Event.fireOut("onCardGroupListChanged", oldValue);
        }
        public override void onReqCardList(CARD_LIST arg1,CARDGROUP_INFO_LIST arg2)
        {
            Debug.LogFormat("获取卡牌列表：{0}", arg1.Count);
            KBEngine.Event.fireOut("onReqCardList", arg1,arg2);
        }

    }
}
