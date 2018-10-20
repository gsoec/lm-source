.class public Lcom/igg/sdk/incident/IGGIncidentCollector;
.super Ljava/lang/Object;
.source "IGGIncidentCollector.java"


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;
    }
.end annotation


# static fields
.field protected static TAG:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 30
    const-string v0, "IGGIncidentCollector"

    sput-object v0, Lcom/igg/sdk/incident/IGGIncidentCollector;->TAG:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 0

    .prologue
    .line 28
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public saveIncident(Lcom/igg/sdk/incident/IGGIncident;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;)V
    .locals 11
    .param p1, "incident"    # Lcom/igg/sdk/incident/IGGIncident;
    .param p2, "version"    # Ljava/lang/String;
    .param p3, "idc"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .param p4, "listener"    # Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;

    .prologue
    const/4 v10, 0x0

    .line 65
    invoke-virtual {p1}, Lcom/igg/sdk/incident/IGGIncident;->getTitle()Ljava/lang/String;

    move-result-object v5

    .line 66
    .local v5, "title":Ljava/lang/String;
    if-eqz v5, :cond_0

    const-string v8, ""

    invoke-virtual {v5, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_1

    .line 67
    :cond_0
    const-string v8, "101"

    const-string v9, "b_title is not null"

    invoke-interface {p4, v10, v8, v9}, Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;->onFinished(ZLjava/lang/String;Ljava/lang/String;)V

    .line 165
    :goto_0
    return-void

    .line 71
    :cond_1
    invoke-virtual {p1}, Lcom/igg/sdk/incident/IGGIncident;->getDescription()Ljava/lang/String;

    move-result-object v2

    .line 72
    .local v2, "note":Ljava/lang/String;
    if-eqz v2, :cond_2

    const-string v8, ""

    invoke-virtual {v2, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_3

    .line 73
    :cond_2
    const-string v8, "102"

    const-string v9, "b_note is not null"

    invoke-interface {p4, v10, v8, v9}, Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;->onFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 77
    :cond_3
    invoke-virtual {p1}, Lcom/igg/sdk/incident/IGGIncident;->getType()Ljava/lang/String;

    move-result-object v6

    .line 78
    .local v6, "type":Ljava/lang/String;
    if-eqz v6, :cond_4

    const-string v8, ""

    invoke-virtual {v6, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-eqz v8, :cond_5

    .line 79
    :cond_4
    const-string v8, "103"

    const-string v9, "b_type is not null"

    invoke-interface {p4, v10, v8, v9}, Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;->onFinished(ZLjava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 83
    :cond_5
    const-string v7, ""

    .line 84
    .local v7, "url":Ljava/lang/String;
    sget-object v8, Lcom/igg/sdk/incident/IGGIncidentCollector$2;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

    invoke-virtual {p3}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->ordinal()I

    move-result v9

    aget v8, v8, v9

    packed-switch v8, :pswitch_data_0

    .line 109
    :goto_1
    new-instance v4, Ljava/util/HashMap;

    invoke-direct {v4}, Ljava/util/HashMap;-><init>()V

    .line 110
    .local v4, "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    const-string v8, "g_id"

    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v9

    invoke-virtual {v9}, Lcom/igg/sdk/IGGSDK;->getGameId()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v4, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 111
    const-string v8, "b_title"

    invoke-virtual {v4, v8, v5}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 112
    const-string v8, "b_note"

    invoke-virtual {v4, v8, v2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 114
    const-string v8, "b_type"

    sget-object v9, Landroid/os/Build;->MODEL:Ljava/lang/String;

    invoke-virtual {v4, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 115
    const-string v8, "b_device_mode"

    invoke-virtual {v4, v8, v6}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 117
    if-eqz p2, :cond_8

    const-string v8, ""

    invoke-virtual {p2, v8}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v8

    if-nez v8, :cond_8

    .line 118
    const-string v8, "b_version_name"

    invoke-virtual {v4, v8, p2}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 124
    :goto_2
    invoke-virtual {p1}, Lcom/igg/sdk/incident/IGGIncident;->getEncodedData()Ljava/lang/String;

    move-result-object v0

    .line 125
    .local v0, "data":Ljava/lang/String;
    if-eqz v0, :cond_6

    .line 126
    const-string v8, "b_info"

    invoke-virtual {v4, v8, v0}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 130
    :cond_6
    invoke-virtual {p1}, Lcom/igg/sdk/incident/IGGIncident;->getExtraFields()Ljava/util/HashMap;

    move-result-object v3

    .line 131
    .local v3, "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    if-eqz v3, :cond_9

    .line 132
    invoke-virtual {v3}, Ljava/util/HashMap;->keySet()Ljava/util/Set;

    move-result-object v8

    invoke-interface {v8}, Ljava/util/Set;->iterator()Ljava/util/Iterator;

    move-result-object v9

    :goto_3
    invoke-interface {v9}, Ljava/util/Iterator;->hasNext()Z

    move-result v8

    if-eqz v8, :cond_9

    invoke-interface {v9}, Ljava/util/Iterator;->next()Ljava/lang/Object;

    move-result-object v1

    check-cast v1, Ljava/lang/String;

    .line 133
    .local v1, "key":Ljava/lang/String;
    invoke-virtual {v3, v1}, Ljava/util/HashMap;->get(Ljava/lang/Object;)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Ljava/lang/String;

    invoke-virtual {v4, v1, v8}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_3

    .line 86
    .end local v0    # "data":Ljava/lang/String;
    .end local v1    # "key":Ljava/lang/String;
    .end local v3    # "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    .end local v4    # "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :pswitch_0
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "collect.snd.igg.com/bugcollect.php"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 87
    goto :goto_1

    .line 90
    :pswitch_1
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v8

    invoke-virtual {v8}, Lcom/igg/sdk/IGGSDK;->getFamily()Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    move-result-object v8

    sget-object v9, Lcom/igg/sdk/IGGSDKConstant$IGGFamily;->FP:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    if-ne v8, v9, :cond_7

    .line 91
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "collect.fantasyplus.game.tw/bugcollect.php"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    goto/16 :goto_1

    .line 93
    :cond_7
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "collect.tw.igg.com/bugcollect.php"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 95
    goto/16 :goto_1

    .line 98
    :pswitch_2
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "collect.sg.igg.com/bugcollect.php"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 99
    goto/16 :goto_1

    .line 102
    :pswitch_3
    new-instance v8, Ljava/lang/StringBuilder;

    invoke-direct {v8}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v9

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    const-string v9, "collect.nl.igg.com/bugcollect.php"

    invoke-virtual {v8, v9}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v8

    invoke-virtual {v8}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v7

    .line 103
    goto/16 :goto_1

    .line 120
    .restart local v4    # "params":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :cond_8
    const-string v8, "b_version_name"

    const-string v9, ""

    invoke-virtual {v4, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto/16 :goto_2

    .line 138
    .restart local v0    # "data":Ljava/lang/String;
    .restart local v3    # "parameters":Ljava/util/HashMap;, "Ljava/util/HashMap<Ljava/lang/String;Ljava/lang/String;>;"
    :cond_9
    const-string v8, "return_format"

    const-string v9, "json"

    invoke-virtual {v4, v8, v9}, Ljava/util/HashMap;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 140
    new-instance v8, Lcom/igg/sdk/service/IGGService;

    invoke-direct {v8}, Lcom/igg/sdk/service/IGGService;-><init>()V

    new-instance v9, Lcom/igg/sdk/incident/IGGIncidentCollector$1;

    invoke-direct {v9, p0, p4}, Lcom/igg/sdk/incident/IGGIncidentCollector$1;-><init>(Lcom/igg/sdk/incident/IGGIncidentCollector;Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;)V

    invoke-virtual {v8, v7, v4, v9}, Lcom/igg/sdk/service/IGGService;->postRequest(Ljava/lang/String;Ljava/util/HashMap;Lcom/igg/sdk/service/IGGService$GeneralRequestListener;)V

    goto/16 :goto_0

    .line 84
    nop

    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
        :pswitch_3
    .end packed-switch
.end method
