.class public Lcom/igg/util/APIUtils;
.super Ljava/lang/Object;
.source "APIUtils.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .prologue
    .line 12
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method

.method public static getSystemAPI()I
    .locals 2

    .prologue
    .line 20
    :try_start_0
    sget v1, Landroid/os/Build$VERSION;->SDK_INT:I
    :try_end_0
    .catch Ljava/lang/NumberFormatException; {:try_start_0 .. :try_end_0} :catch_0

    .line 25
    .local v1, "tmpSdkVersion":I
    :goto_0
    return v1

    .line 21
    .end local v1    # "tmpSdkVersion":I
    :catch_0
    move-exception v0

    .line 22
    .local v0, "e":Ljava/lang/NumberFormatException;
    const/4 v1, 0x0

    .restart local v1    # "tmpSdkVersion":I
    goto :goto_0
.end method

.method public static hasHoneycomb()Z
    .locals 2

    .prologue
    .line 14
    sget v0, Landroid/os/Build$VERSION;->SDK_INT:I

    const/16 v1, 0xb

    if-lt v0, v1, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    goto :goto_0
.end method
