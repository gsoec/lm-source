.class public Lcom/igg/iggsdkbusiness/CollectionInformation;
.super Ljava/lang/Object;
.source "CollectionInformation.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "CollectionInformation"

.field private static instance:Lcom/igg/iggsdkbusiness/CollectionInformation;

.field public static lastAccount:Ljava/lang/String;


# instance fields
.field FailedCallBack:Ljava/lang/String;

.field SuccessfulCallBack:Ljava/lang/String;

.field setValueCallback:Ljava/lang/String;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 17
    const-string v0, ""

    sput-object v0, Lcom/igg/iggsdkbusiness/CollectionInformation;->lastAccount:Ljava/lang/String;

    return-void
.end method

.method public constructor <init>()V
    .locals 1

    .prologue
    .line 20
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 32
    const-string v0, "collectSuccessfulCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation;->SuccessfulCallBack:Ljava/lang/String;

    .line 34
    const-string v0, "collectFailedCallBack"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation;->FailedCallBack:Ljava/lang/String;

    .line 35
    const-string v0, "setValueCallback"

    iput-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation;->setValueCallback:Ljava/lang/String;

    .line 21
    return-void
.end method

.method public static sharedInstance()Lcom/igg/iggsdkbusiness/CollectionInformation;
    .locals 1

    .prologue
    .line 24
    sget-object v0, Lcom/igg/iggsdkbusiness/CollectionInformation;->instance:Lcom/igg/iggsdkbusiness/CollectionInformation;

    if-nez v0, :cond_0

    .line 25
    new-instance v0, Lcom/igg/iggsdkbusiness/CollectionInformation;

    invoke-direct {v0}, Lcom/igg/iggsdkbusiness/CollectionInformation;-><init>()V

    sput-object v0, Lcom/igg/iggsdkbusiness/CollectionInformation;->instance:Lcom/igg/iggsdkbusiness/CollectionInformation;

    .line 28
    :cond_0
    sget-object v0, Lcom/igg/iggsdkbusiness/CollectionInformation;->instance:Lcom/igg/iggsdkbusiness/CollectionInformation;

    return-object v0
.end method


# virtual methods
.method CallBack(Ljava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p1, "pFunctionName"    # Ljava/lang/String;
    .param p2, "pCallBackString"    # Ljava/lang/String;

    .prologue
    .line 38
    const-string v0, "log:"

    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    invoke-virtual {v1, p1}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    const-string v2, ":"

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1, p2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    invoke-static {v0, v1}, Landroid/util/Log;->i(Ljava/lang/String;Ljava/lang/String;)I

    .line 39
    invoke-static {}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->instance()Lcom/igg/iggsdkbusiness/IGGSDKPlugin;

    move-result-object v0

    invoke-virtual {v0, p1, p2}, Lcom/igg/iggsdkbusiness/IGGSDKPlugin;->SendMessageToUnity(Ljava/lang/String;Ljava/lang/String;)V

    .line 40
    return-void
.end method

.method public saveIncident(Lcom/igg/sdk/incident/IGGIncident;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGIDC;)V
    .locals 2
    .param p1, "incident"    # Lcom/igg/sdk/incident/IGGIncident;
    .param p2, "version"    # Ljava/lang/String;
    .param p3, "idc"    # Lcom/igg/sdk/IGGSDKConstant$IGGIDC;

    .prologue
    .line 50
    if-eqz p2, :cond_0

    const-string v0, ""

    invoke-virtual {p2, v0}, Ljava/lang/String;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_1

    .line 51
    :cond_0
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation;->setValueCallback:Ljava/lang/String;

    const-string v1, "\u5ba2\u6237\u7aef\u7248\u672c\u53f7\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    .line 92
    :goto_0
    return-void

    .line 55
    :cond_1
    if-nez p3, :cond_2

    .line 56
    iget-object v0, p0, Lcom/igg/iggsdkbusiness/CollectionInformation;->setValueCallback:Ljava/lang/String;

    const-string v1, "\u670d\u52a1\u5668\u8282\u70b9\u7c7b\u578b\u4e0d\u80fd\u4e3a\u7a7a"

    invoke-virtual {p0, v0, v1}, Lcom/igg/iggsdkbusiness/CollectionInformation;->CallBack(Ljava/lang/String;Ljava/lang/String;)V

    goto :goto_0

    .line 60
    :cond_2
    new-instance v0, Lcom/igg/sdk/incident/IGGIncidentCollector;

    invoke-direct {v0}, Lcom/igg/sdk/incident/IGGIncidentCollector;-><init>()V

    new-instance v1, Lcom/igg/iggsdkbusiness/CollectionInformation$1;

    invoke-direct {v1, p0}, Lcom/igg/iggsdkbusiness/CollectionInformation$1;-><init>(Lcom/igg/iggsdkbusiness/CollectionInformation;)V

    invoke-virtual {v0, p1, p2, p3, v1}, Lcom/igg/sdk/incident/IGGIncidentCollector;->saveIncident(Lcom/igg/sdk/incident/IGGIncident;Ljava/lang/String;Lcom/igg/sdk/IGGSDKConstant$IGGIDC;Lcom/igg/sdk/incident/IGGIncidentCollector$IncidentListener;)V

    goto :goto_0
.end method
