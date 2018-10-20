.class public Lcom/igg/util/FilterMacAddress;
.super Ljava/lang/Object;
.source "FilterMacAddress.java"


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

.method public static filterIsInvalidMacAdress(Ljava/lang/String;)Ljava/lang/String;
    .locals 1
    .param p0, "macAddress"    # Ljava/lang/String;

    .prologue
    .line 46
    invoke-static {p0}, Lcom/igg/util/FilterMacAddress;->isInvalidMacAdress(Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 47
    const-string p0, ""

    .line 49
    .end local p0    # "macAddress":Ljava/lang/String;
    :cond_0
    return-object p0
.end method

.method public static isInvalidMacAdress(Ljava/lang/String;)Z
    .locals 4
    .param p0, "macAddress"    # Ljava/lang/String;

    .prologue
    .line 17
    :try_start_0
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    .line 22
    .local v1, "tmpSdkVersion":I
    :goto_0
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    if-nez v2, :cond_0

    .line 23
    new-instance v2, Ljava/util/ArrayList;

    invoke-direct {v2}, Ljava/util/ArrayList;-><init>()V

    sput-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    .line 24
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "00:DA:36:16:DE:EB"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 25
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "00:90:4C:C5:12:38"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 26
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "00:90:4C:C5:00:34"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 27
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "00:11:22:33:44:55"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 28
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "00:00:00:00:00:00"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 29
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "08:00:28:12:34:56"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 30
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "88:f4:88:00:00:01"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 31
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "DE:FA:CE:DE:FA:CE"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 32
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "08:00:28:12:03:58"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 33
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "00:08:22:ba:b3:fb"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 34
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "38:16:d1:85:d0:a0"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 35
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "38:AA:3C:08:EA:55"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 36
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "10:A5:F1:83:C0:A0"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 37
    const/16 v2, 0x17

    if-lt v1, v2, :cond_0

    .line 38
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    const-string v3, "02:00:00:00:00:00"

    invoke-interface {v2, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 42
    :cond_0
    sget-object v2, Lcom/igg/util/FilterMacAddress;->list:Ljava/util/List;

    invoke-interface {v2, p0}, Ljava/util/List;->contains(Ljava/lang/Object;)Z

    move-result v2

    return v2

    .line 18
    .end local v1    # "tmpSdkVersion":I
    :catch_0
    move-exception v0

    .line 19
    .local v0, "e":Ljava/lang/NumberFormatException;
    const/4 v1, 0x0

    .restart local v1    # "tmpSdkVersion":I
    goto :goto_0
.end method
