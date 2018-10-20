.class Lcom/igg/iggsdkbusiness/IGGSDKPlugin$6;
.super Ljava/lang/Object;
.source "IGGSDKPlugin.java"

# interfaces
.implements Lcom/igg/sdk/IGGGameDelegate;


# annotations
.annotation system Ldalvik/annotation/EnclosingMethod;
    value = Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->BuyProduct(Ljava/lang/String;I)V
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x0
    name = null
.end annotation


# instance fields
.field final synthetic this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

.field final synthetic val$serverId:I


# direct methods
.method constructor <init>(Lcom/igg/iggsdkbusiness/IGGSDKPlugin;I)V
    .locals 0
    .param p1, "this$0"    # Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    .prologue
    .line 341
    iput-object p1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$6;->this$0:Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    iput p2, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$6;->val$serverId:I

    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getCharacter()Lcom/igg/sdk/bean/IGGCharacter;
    .locals 2

    .prologue
    .line 344
    new-instance v0, Lcom/igg/sdk/bean/IGGCharacter;

    invoke-direct {v0}, Lcom/igg/sdk/bean/IGGCharacter;-><init>()V

    .line 347
    .local v0, "character":Lcom/igg/sdk/bean/IGGCharacter;
    const-string v1, "0"

    invoke-virtual {v0, v1}, Lcom/igg/sdk/bean/IGGCharacter;->setCharId(Ljava/lang/String;)V

    .line 349
    const-string v1, "0"

    invoke-virtual {v0, v1}, Lcom/igg/sdk/bean/IGGCharacter;->setCharName(Ljava/lang/String;)V

    .line 351
    const-string v1, "0"

    invoke-virtual {v0, v1}, Lcom/igg/sdk/bean/IGGCharacter;->setLevel(Ljava/lang/String;)V

    .line 352
    return-object v0
.end method

.method public getServerInfo()Lcom/igg/sdk/bean/IGGServerInfo;
    .locals 2

    .prologue
    .line 356
    new-instance v0, Lcom/igg/sdk/bean/IGGServerInfo;

    invoke-direct {v0}, Lcom/igg/sdk/bean/IGGServerInfo;-><init>()V

    .line 358
    .local v0, "serverInfo":Lcom/igg/sdk/bean/IGGServerInfo;
    iget v1, p0, Lcom/igg/iggsdkbusiness/IGGSDKPlugin$6;->val$serverId:I

    invoke-static {v1}, Ljava/lang/Integer;->toString(I)Ljava/lang/String;

    move-result-object v1

    invoke-virtual {v0, v1}, Lcom/igg/sdk/bean/IGGServerInfo;->setServerId(Ljava/lang/String;)V

    .line 359
    return-object v0
.end method
