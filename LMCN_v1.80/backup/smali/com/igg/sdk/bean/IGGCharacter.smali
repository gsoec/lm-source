.class public Lcom/igg/sdk/bean/IGGCharacter;
.super Ljava/lang/Object;
.source "IGGCharacter.java"


# instance fields
.field private charId:Ljava/lang/String;

.field private charName:Ljava/lang/String;

.field private level:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 3
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getCharId()Ljava/lang/String;
    .locals 1

    .prologue
    .line 9
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGCharacter;->charId:Ljava/lang/String;

    return-object v0
.end method

.method public getCharName()Ljava/lang/String;
    .locals 1

    .prologue
    .line 17
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGCharacter;->charName:Ljava/lang/String;

    return-object v0
.end method

.method public getLevel()Ljava/lang/String;
    .locals 1

    .prologue
    .line 25
    iget-object v0, p0, Lcom/igg/sdk/bean/IGGCharacter;->level:Ljava/lang/String;

    return-object v0
.end method

.method public setCharId(Ljava/lang/String;)V
    .locals 0
    .param p1, "charId"    # Ljava/lang/String;

    .prologue
    .line 13
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGCharacter;->charId:Ljava/lang/String;

    .line 14
    return-void
.end method

.method public setCharName(Ljava/lang/String;)V
    .locals 0
    .param p1, "charName"    # Ljava/lang/String;

    .prologue
    .line 21
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGCharacter;->charName:Ljava/lang/String;

    .line 22
    return-void
.end method

.method public setLevel(Ljava/lang/String;)V
    .locals 0
    .param p1, "level"    # Ljava/lang/String;

    .prologue
    .line 29
    iput-object p1, p0, Lcom/igg/sdk/bean/IGGCharacter;->level:Ljava/lang/String;

    .line 30
    return-void
.end method
