.class public Lcom/igg/sdk/IGGStorage;
.super Ljava/lang/Object;
.source "IGGStorage.java"


# instance fields
.field private idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;


# direct methods
.method public constructor <init>(Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
    .locals 0
    .param p1, "idc"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .prologue
    .line 24
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 25
    iput-object p1, p0, Lcom/igg/sdk/IGGStorage;->idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .line 26
    return-void
.end method


# virtual methods
.method public getAPIURL(Ljava/lang/String;)Ljava/lang/String;
    .locals 3
    .param p1, "URI"    # Ljava/lang/String;

    .prologue
    .line 44
    const-string v0, ""

    .line 45
    .local v0, "url":Ljava/lang/String;
    sget-object v1, Lcom/igg/sdk/IGGStorage$1;->$SwitchMap$com$igg$sdk$IGGSDKConstant$IGGIDC:[I

    iget-object v2, p0, Lcom/igg/sdk/IGGStorage;->idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    invoke-virtual {v2}, Lcom/igg/sdk/IGGSDKConstant$IGGIDC;->ordinal()I

    move-result v2

    aget v1, v1, v2

    packed-switch v1, :pswitch_data_0

    .line 71
    :goto_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, v0}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 72
    return-object v0

    .line 47
    :pswitch_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "snd-storage.igg.com/"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 48
    goto :goto_0

    .line 51
    :pswitch_1
    invoke-static {}, Lcom/igg/sdk/IGGSDK;->sharedInstance()Lcom/igg/sdk/IGGSDK;

    move-result-object v1

    invoke-virtual {v1}, Lcom/igg/sdk/IGGSDK;->getFamily()Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    move-result-object v1

    sget-object v2, Lcom/igg/sdk/IGGSDKConstant$IGGFamily;->FP:Lcom/igg/sdk/IGGSDKConstant$IGGFamily;

    if-ne v1, v2, :cond_0

    .line 52
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "tw-storage.fantasyplus.game.tw/"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    goto :goto_0

    .line 54
    :cond_0
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "tw-storage.igg.com/"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 57
    goto :goto_0

    .line 60
    :pswitch_2
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "sg-storage.igg.com/"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 61
    goto :goto_0

    .line 64
    :pswitch_3
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-static {}, Lcom/igg/sdk/IGGURLHelper;->getHttpHead()Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, "eu-storage.igg.com/"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v0

    .line 65
    goto/16 :goto_0

    .line 45
    :pswitch_data_0
    .packed-switch 0x1
        :pswitch_0
        :pswitch_1
        :pswitch_2
        :pswitch_3
    .end packed-switch
.end method

.method public getNode()Lcom/igg/sdk/IGGSDKConstant$IGGIDC;
    .locals 1

    .prologue
    .line 34
    iget-object v0, p0, Lcom/igg/sdk/IGGStorage;->idc:Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    return-object v0
.end method
