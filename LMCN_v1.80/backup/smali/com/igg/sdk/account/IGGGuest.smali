.class public Lcom/igg/sdk/account/IGGGuest;
.super Ljava/lang/Object;
.source "IGGGuest.java"


# static fields
.field public static final TAG:Ljava/lang/String; = "IGGGuest"


# instance fields
.field protected identifier:Ljava/lang/String;


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public getIdentifier()Ljava/lang/String;
    .locals 1
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 38
    iget-object v0, p0, Lcom/igg/sdk/account/IGGGuest;->identifier:Ljava/lang/String;

    return-object v0
.end method

.method public getReadableIdentifier()Ljava/lang/String;
    .locals 1

    .prologue
    .line 29
    iget-object v0, p0, Lcom/igg/sdk/account/IGGGuest;->identifier:Ljava/lang/String;

    return-object v0
.end method

.method public setIdentifier(Ljava/lang/String;)V
    .locals 0
    .param p1, "identifier"    # Ljava/lang/String;
    .annotation system Ldalvik/annotation/Throws;
        value = {
            Ljava/lang/Exception;
        }
    .end annotation

    .prologue
    .line 48
    iput-object p1, p0, Lcom/igg/sdk/account/IGGGuest;->identifier:Ljava/lang/String;

    .line 49
    return-void
.end method
