.class public Lcom/igg/android/wegamers/auth/AuthInfo;
.super Ljava/lang/Object;
.source "AuthInfo.java"


# instance fields
.field private gameId:Ljava/lang/String;

.field private gameUserId:Ljava/lang/String;

.field private token:Ljava/lang/String;

.field private userIggId:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 9
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getGameId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 41
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->gameId:Ljava/lang/String;

    return-object v0
.end method

.method public getGameUserId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 33
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->gameUserId:Ljava/lang/String;

    return-object v0
.end method

.method public getToken()Ljava/lang/String;
    .locals 1

    .prologue
    .line 17
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->token:Ljava/lang/String;

    return-object v0
.end method

.method public getUserIggId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->userIggId:Ljava/lang/String;

    return-object v0
.end method

.method public setGameId(Ljava/lang/String;)V
    .locals 0
    .param p1, "gameId"    # Ljava/lang/String;

    .prologue
    .line 45
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->gameId:Ljava/lang/String;

    .line 46
    return-void
.end method

.method public setGameUserId(Ljava/lang/String;)V
    .locals 0
    .param p1, "gameUserId"    # Ljava/lang/String;

    .prologue
    .line 37
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->gameUserId:Ljava/lang/String;

    .line 38
    return-void
.end method

.method public setToken(Ljava/lang/String;)V
    .locals 0
    .param p1, "token"    # Ljava/lang/String;

    .prologue
    .line 21
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->token:Ljava/lang/String;

    .line 22
    return-void
.end method

.method public setUserIggId(Ljava/lang/String;)V
    .locals 0
    .param p1, "userIggId"    # Ljava/lang/String;

    .prologue
    .line 29
    iput-object p1, p0, Lcom/igg/android/wegamers/auth/AuthInfo;->userIggId:Ljava/lang/String;

    .line 30
    return-void
.end method
