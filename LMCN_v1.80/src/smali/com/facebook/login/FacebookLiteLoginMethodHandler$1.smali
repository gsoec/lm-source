.class final Lcom/facebook/login/FacebookLiteLoginMethodHandler$1;
.super Ljava/lang/Object;
.source "FacebookLiteLoginMethodHandler.java"

# interfaces
.implements Landroid/os/Parcelable$Creator;


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/facebook/login/FacebookLiteLoginMethodHandler;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x8
    name = null
.end annotation


# direct methods
.method constructor <init>()V
    .locals 0

    .prologue
    .line 82
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public createFromParcel(Landroid/os/Parcel;)Lcom/facebook/login/FacebookLiteLoginMethodHandler;
    .locals 1
    .param p1, "source"    # Landroid/os/Parcel;

    .prologue
    .line 86
    new-instance v0, Lcom/facebook/login/FacebookLiteLoginMethodHandler;

    invoke-direct {v0, p1}, Lcom/facebook/login/FacebookLiteLoginMethodHandler;-><init>(Landroid/os/Parcel;)V

    return-object v0
.end method

.method public bridge synthetic createFromParcel(Landroid/os/Parcel;)Ljava/lang/Object;
    .locals 1

    .prologue
    .line 82
    invoke-virtual {p0, p1}, Lcom/facebook/login/FacebookLiteLoginMethodHandler$1;->createFromParcel(Landroid/os/Parcel;)Lcom/facebook/login/FacebookLiteLoginMethodHandler;

    move-result-object v0

    return-object v0
.end method

.method public newArray(I)[Lcom/facebook/login/FacebookLiteLoginMethodHandler;
    .locals 1
    .param p1, "size"    # I

    .prologue
    .line 91
    new-array v0, p1, [Lcom/facebook/login/FacebookLiteLoginMethodHandler;

    return-object v0
.end method

.method public bridge synthetic newArray(I)[Ljava/lang/Object;
    .locals 1

    .prologue
    .line 82
    invoke-virtual {p0, p1}, Lcom/facebook/login/FacebookLiteLoginMethodHandler$1;->newArray(I)[Lcom/facebook/login/FacebookLiteLoginMethodHandler;

    move-result-object v0

    return-object v0
.end method
