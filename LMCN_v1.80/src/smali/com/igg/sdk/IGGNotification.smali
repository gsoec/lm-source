.class public Lcom/igg/sdk/IGGNotification;
.super Ljava/lang/Object;
.source "IGGNotification.java"


# instance fields
.field private name:Ljava/lang/String;

.field private object:Ljava/lang/Object;

.field private userInfo:Ljava/lang/Object;


# direct methods
.method public constructor <init>(Ljava/lang/String;)V
    .locals 1
    .param p1, "name"    # Ljava/lang/String;

    .prologue
    const/4 v0, 0x0

    .line 32
    invoke-direct {p0, p1, v0, v0}, Lcom/igg/sdk/IGGNotification;-><init>(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V

    .line 33
    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/lang/Object;)V
    .locals 1
    .param p1, "name"    # Ljava/lang/String;
    .param p2, "object"    # Ljava/lang/Object;

    .prologue
    .line 36
    const/4 v0, 0x0

    invoke-direct {p0, p1, p2, v0}, Lcom/igg/sdk/IGGNotification;-><init>(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V

    .line 37
    return-void
.end method

.method public constructor <init>(Ljava/lang/String;Ljava/lang/Object;Ljava/lang/Object;)V
    .locals 0
    .param p1, "name"    # Ljava/lang/String;
    .param p2, "object"    # Ljava/lang/Object;
    .param p3, "userInfo"    # Ljava/lang/Object;

    .prologue
    .line 39
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 40
    iput-object p1, p0, Lcom/igg/sdk/IGGNotification;->name:Ljava/lang/String;

    .line 41
    iput-object p2, p0, Lcom/igg/sdk/IGGNotification;->object:Ljava/lang/Object;

    .line 42
    iput-object p3, p0, Lcom/igg/sdk/IGGNotification;->userInfo:Ljava/lang/Object;

    .line 43
    return-void
.end method


# virtual methods
.method public getName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 53
    iget-object v0, p0, Lcom/igg/sdk/IGGNotification;->name:Ljava/lang/String;

    return-object v0
.end method

.method public getObject()Ljava/lang/Object;
    .locals 1

    .prologue
    .line 60
    iget-object v0, p0, Lcom/igg/sdk/IGGNotification;->object:Ljava/lang/Object;

    return-object v0
.end method

.method public getUserInfo()Ljava/lang/Object;
    .locals 1

    .prologue
    .line 69
    iget-object v0, p0, Lcom/igg/sdk/IGGNotification;->userInfo:Ljava/lang/Object;

    return-object v0
.end method
