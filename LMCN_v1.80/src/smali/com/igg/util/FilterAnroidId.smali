.class public Lcom/igg/util/FilterAnroidId;
.super Ljava/lang/Object;
.source "FilterAnroidId.java"


# static fields
.field private static list:Ljava/util/List;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Ljava/util/List",
            "<",
            "Ljava/lang/String;",
            ">;"
        }
    .end annotation
.end field


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 11
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static filterIsInvalidAnroidId(Ljava/lang/String;)Ljava/lang/String;
    .locals 1
    .param p0, "anroidId"    # Ljava/lang/String;

    .prologue
    .line 25
    invoke-static {p0}, Lcom/igg/util/FilterAnroidId;->isInvalidAnroidId(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 26
    const-string p0, ""

    .line 28
    .end local p0    # "anroidId":Ljava/lang/String;
    :cond_0
    return-object p0
.end method

.method public static isInvalidAnroidId(Ljava/lang/String;)Z
    .locals 2
    .param p0, "anroidId"    # Ljava/lang/String;

    .prologue
    .line 16
    sget-object v0, Lcom/igg/util/FilterAnroidId;->list:Ljava/util/List;

    if-nez v0, :cond_0

    .line 17
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    sput-object v0, Lcom/igg/util/FilterAnroidId;->list:Ljava/util/List;

    .line 18
    sget-object v0, Lcom/igg/util/FilterAnroidId;->list:Ljava/util/List;

    const-string v1, "000000000000000"

    invoke-interface {v0, v1}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 21
    :cond_0
    sget-object v0, Lcom/igg/util/FilterAnroidId;->list:Ljava/util/List;

    invoke-interface {v0, p0}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v0

    return v0
.end method
