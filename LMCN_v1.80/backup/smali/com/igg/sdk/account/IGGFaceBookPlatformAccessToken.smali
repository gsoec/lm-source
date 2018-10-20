.class public Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;
.super Ljava/lang/Object;
.source "IGGFaceBookPlatformAccessToken.java"


# instance fields
.field private tokenString:Ljava/lang/String;

.field private userID:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 6
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getTokenString()Ljava/lang/String;
    .locals 1

    .prologue
    .line 19
    iget-object v0, p0, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->tokenString:Ljava/lang/String;

    return-object v0
.end method

.method public getUserID()Ljava/lang/String;
    .locals 1

    .prologue
    .line 11
    iget-object v0, p0, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->userID:Ljava/lang/String;

    return-object v0
.end method

.method public setTokenString(Ljava/lang/String;)V
    .locals 0
    .param p1, "tokenString"    # Ljava/lang/String;

    .prologue
    .line 23
    iput-object p1, p0, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->tokenString:Ljava/lang/String;

    .line 24
    return-void
.end method

.method public setUserID(Ljava/lang/String;)V
    .locals 0
    .param p1, "userID"    # Ljava/lang/String;

    .prologue
    .line 15
    iput-object p1, p0, Lcom/igg/sdk/account/IGGFaceBookPlatformAccessToken;->userID:Ljava/lang/String;

    .line 16
    return-void
.end method
