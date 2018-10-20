.class final Lcom/appsflyer/g;
.super Ljava/lang/Object;
.source ""

# interfaces
.implements Landroid/hardware/SensorEventListener;


# instance fields
.field private final ʻ:I

.field private ʽ:D

.field private final ˊ:[[F

.field private final ˋ:Ljava/lang/String;
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation
.end field

.field private final ˎ:Ljava/lang/String;
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation
.end field

.field private final ˏ:I

.field private final ॱ:[J

.field private ॱॱ:J


# direct methods
.method private constructor <init>(ILjava/lang/String;Ljava/lang/String;)V
    .locals 3
    .param p2    # Ljava/lang/String;
        .annotation build Landroid/support/annotation/Nullable;
        .end annotation
    .end param
    .param p3    # Ljava/lang/String;
        .annotation build Landroid/support/annotation/Nullable;
        .end annotation
    .end param

    .prologue
    const/4 v1, 0x2

    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 31
    new-array v0, v1, [[F

    iput-object v0, p0, Lcom/appsflyer/g;->ˊ:[[F

    .line 32
    new-array v0, v1, [J

    iput-object v0, p0, Lcom/appsflyer/g;->ॱ:[J

    .line 38
    iput p1, p0, Lcom/appsflyer/g;->ˏ:I

    .line 4046
    if-nez p2, :cond_0

    const-string p2, ""

    .line 39
    :cond_0
    iput-object p2, p0, Lcom/appsflyer/g;->ˎ:Ljava/lang/String;

    .line 6046
    if-nez p3, :cond_1

    const-string p3, ""

    .line 40
    :cond_1
    iput-object p3, p0, Lcom/appsflyer/g;->ˋ:Ljava/lang/String;

    .line 41
    iget-object v0, p0, Lcom/appsflyer/g;->ˎ:Ljava/lang/String;

    iget-object v1, p0, Lcom/appsflyer/g;->ˋ:Ljava/lang/String;

    .line 6051
    add-int/lit8 v2, p1, 0x1f

    .line 6052
    mul-int/lit8 v2, v2, 0x1f

    invoke-virtual {v0}, Ljava/lang/Object;->hashCode()I

    move-result v0

    add-int/2addr v0, v2

    .line 6053
    mul-int/lit8 v0, v0, 0x1f

    invoke-virtual {v1}, Ljava/lang/Object;->hashCode()I

    move-result v1

    add-int/2addr v0, v1

    .line 41
    iput v0, p0, Lcom/appsflyer/g;->ʻ:I

    .line 42
    return-void
.end method

.method private ˊ()Ljava/util/Map;
    .locals 3
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "()",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;"
        }
    .end annotation

    .prologue
    .line 188
    new-instance v0, Ljava/util/HashMap;

    const/4 v1, 0x7

    invoke-direct {v0, v1}, Ljava/util/HashMap;-><init>(I)V

    .line 189
    const-string v1, "sT"

    iget v2, p0, Lcom/appsflyer/g;->ˏ:I

    invoke-static {v2}, Ljava/lang/Integer;->valueOf(I)Ljava/lang/Integer;

    move-result-object v2

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 190
    const-string v1, "sN"

    iget-object v2, p0, Lcom/appsflyer/g;->ˎ:Ljava/lang/String;

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 191
    const-string v1, "sV"

    iget-object v2, p0, Lcom/appsflyer/g;->ˋ:Ljava/lang/String;

    invoke-interface {v0, v1, v2}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 192
    iget-object v1, p0, Lcom/appsflyer/g;->ˊ:[[F

    const/4 v2, 0x0

    aget-object v1, v1, v2

    .line 193
    if-eqz v1, :cond_0

    .line 194
    const-string v2, "sVS"

    invoke-static {v1}, Lcom/appsflyer/g;->ˋ([F)Ljava/util/List;

    move-result-object v1

    invoke-interface {v0, v2, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 196
    :cond_0
    iget-object v1, p0, Lcom/appsflyer/g;->ˊ:[[F

    const/4 v2, 0x1

    aget-object v1, v1, v2

    .line 197
    if-eqz v1, :cond_1

    .line 198
    const-string v2, "sVE"

    invoke-static {v1}, Lcom/appsflyer/g;->ˋ([F)Ljava/util/List;

    move-result-object v1

    invoke-interface {v0, v2, v1}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 200
    :cond_1
    return-object v0
.end method

.method private static ˋ([F)Ljava/util/List;
    .locals 4
    .param p0    # [F
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .annotation build Landroid/support/annotation/NonNull;
    .end annotation

    .annotation system Ldalvik/annotation/Signature;
        value = {
            "([F)",
            "Ljava/util/List",
            "<",
            "Ljava/lang/Float;",
            ">;"
        }
    .end annotation

    .prologue
    .line 84
    new-instance v1, Ljava/util/ArrayList;

    array-length v0, p0

    invoke-direct {v1, v0}, Ljava/util/ArrayList;-><init>(I)V

    .line 85
    array-length v2, p0

    const/4 v0, 0x0

    :goto_0
    if-ge v0, v2, :cond_0

    aget v3, p0, v0

    .line 86
    invoke-static {v3}, Ljava/lang/Float;->valueOf(F)Ljava/lang/Float;

    move-result-object v3

    invoke-interface {v1, v3}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    .line 85
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 88
    :cond_0
    return-object v1
.end method

.method private static ˎ([F[F)D
    .locals 8
    .param p0    # [F
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .param p1    # [F
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param

    .prologue
    .line 70
    array-length v0, p0

    array-length v1, p1

    invoke-static {v0, v1}, Ljava/lang/Math;->min(II)I

    move-result v1

    .line 71
    const-wide/16 v2, 0x0

    .line 72
    const/4 v0, 0x0

    :goto_0
    if-ge v0, v1, :cond_0

    .line 73
    aget v4, p0, v0

    aget v5, p1, v0

    sub-float/2addr v4, v5

    float-to-double v4, v4

    const-wide/high16 v6, 0x4000000000000000L    # 2.0

    invoke-static {v4, v5, v6, v7}, Ljava/lang/StrictMath;->pow(DD)D

    move-result-wide v4

    add-double/2addr v2, v4

    .line 72
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 75
    :cond_0
    invoke-static {v2, v3}, Ljava/lang/Math;->sqrt(D)D

    move-result-wide v0

    return-wide v0
.end method

.method private ˎ()V
    .locals 8

    .prologue
    const-wide/16 v6, 0x0

    const/4 v4, 0x2

    const/4 v0, 0x0

    .line 208
    move v1, v0

    :goto_0
    if-ge v1, v4, :cond_0

    .line 209
    iget-object v2, p0, Lcom/appsflyer/g;->ˊ:[[F

    const/4 v3, 0x0

    aput-object v3, v2, v1

    .line 208
    add-int/lit8 v1, v1, 0x1

    goto :goto_0

    .line 211
    :cond_0
    :goto_1
    if-ge v0, v4, :cond_1

    .line 212
    iget-object v1, p0, Lcom/appsflyer/g;->ॱ:[J

    aput-wide v6, v1, v0

    .line 211
    add-int/lit8 v0, v0, 0x1

    goto :goto_1

    .line 214
    :cond_1
    const-wide/16 v0, 0x0

    iput-wide v0, p0, Lcom/appsflyer/g;->ʽ:D

    .line 215
    iput-wide v6, p0, Lcom/appsflyer/g;->ॱॱ:J

    .line 216
    return-void
.end method

.method private ˎ(ILjava/lang/String;Ljava/lang/String;)Z
    .locals 1
    .param p2    # Ljava/lang/String;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .param p3    # Ljava/lang/String;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param

    .prologue
    .line 139
    iget v0, p0, Lcom/appsflyer/g;->ˏ:I

    if-ne v0, p1, :cond_0

    iget-object v0, p0, Lcom/appsflyer/g;->ˎ:Ljava/lang/String;

    .line 140
    invoke-virtual {v0, p2}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    iget-object v0, p0, Lcom/appsflyer/g;->ˋ:Ljava/lang/String;

    .line 141
    invoke-virtual {v0, p3}, Ljava/lang/Object;->equals(Ljava/lang/Object;)Z

    move-result v0

    if-eqz v0, :cond_0

    const/4 v0, 0x1

    :goto_0
    return v0

    :cond_0
    const/4 v0, 0x0

    .line 139
    goto :goto_0
.end method

.method static ॱ(Landroid/hardware/Sensor;)Lcom/appsflyer/g;
    .locals 4

    .prologue
    .line 58
    invoke-virtual {p0}, Landroid/hardware/Sensor;->getType()I

    move-result v0

    invoke-virtual {p0}, Landroid/hardware/Sensor;->getName()Ljava/lang/String;

    move-result-object v1

    invoke-virtual {p0}, Landroid/hardware/Sensor;->getVendor()Ljava/lang/String;

    move-result-object v2

    .line 6062
    new-instance v3, Lcom/appsflyer/g;

    invoke-direct {v3, v0, v1, v2}, Lcom/appsflyer/g;-><init>(ILjava/lang/String;Ljava/lang/String;)V

    .line 58
    return-object v3
.end method

.method private ॱ(Ljava/util/Map;Z)V
    .locals 2
    .param p1    # Ljava/util/Map;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Lcom/appsflyer/g;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;>;Z)V"
        }
    .end annotation

    .prologue
    const/4 v0, 0x0

    .line 128
    .line 7224
    iget-object v1, p0, Lcom/appsflyer/g;->ˊ:[[F

    aget-object v1, v1, v0

    if-eqz v1, :cond_0

    const/4 v0, 0x1

    .line 128
    :cond_0
    if-eqz v0, :cond_2

    .line 129
    invoke-direct {p0}, Lcom/appsflyer/g;->ˊ()Ljava/util/Map;

    move-result-object v0

    invoke-interface {p1, p0, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    .line 130
    if-eqz p2, :cond_1

    .line 131
    invoke-direct {p0}, Lcom/appsflyer/g;->ˎ()V

    .line 136
    :cond_1
    :goto_0
    return-void

    .line 133
    :cond_2
    invoke-interface {p1, p0}, Ljava/util/Map;->containsKey(Ljava/lang/Object;)Z

    move-result v0

    if-nez v0, :cond_1

    .line 134
    invoke-direct {p0}, Lcom/appsflyer/g;->ˊ()Ljava/util/Map;

    move-result-object v0

    invoke-interface {p1, p0, v0}, Ljava/util/Map;->put(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;

    goto :goto_0
.end method


# virtual methods
.method public final equals(Ljava/lang/Object;)Z
    .locals 3

    .prologue
    .line 238
    if-ne p1, p0, :cond_0

    .line 239
    const/4 v0, 0x1

    .line 245
    :goto_0
    return v0

    .line 241
    :cond_0
    instance-of v0, p1, Lcom/appsflyer/g;

    if-eqz v0, :cond_1

    .line 242
    check-cast p1, Lcom/appsflyer/g;

    .line 243
    iget v0, p1, Lcom/appsflyer/g;->ˏ:I

    iget-object v1, p1, Lcom/appsflyer/g;->ˎ:Ljava/lang/String;

    iget-object v2, p1, Lcom/appsflyer/g;->ˋ:Ljava/lang/String;

    invoke-direct {p0, v0, v1, v2}, Lcom/appsflyer/g;->ˎ(ILjava/lang/String;Ljava/lang/String;)Z

    move-result v0

    goto :goto_0

    .line 245
    :cond_1
    const/4 v0, 0x0

    goto :goto_0
.end method

.method public final hashCode()I
    .locals 1

    .prologue
    .line 229
    iget v0, p0, Lcom/appsflyer/g;->ʻ:I

    return v0
.end method

.method public final onAccuracyChanged(Landroid/hardware/Sensor;I)V
    .locals 0

    .prologue
    .line 102
    return-void
.end method

.method public final onSensorChanged(Landroid/hardware/SensorEvent;)V
    .locals 14

    .prologue
    const/4 v2, 0x0

    const/4 v1, 0x1

    .line 93
    if-eqz p1, :cond_0

    iget-object v0, p1, Landroid/hardware/SensorEvent;->values:[F

    if-eqz v0, :cond_0

    iget-object v0, p1, Landroid/hardware/SensorEvent;->sensor:Landroid/hardware/Sensor;

    .line 6079
    if-eqz v0, :cond_1

    invoke-virtual {v0}, Landroid/hardware/Sensor;->getName()Ljava/lang/String;

    move-result-object v3

    if-eqz v3, :cond_1

    invoke-virtual {v0}, Landroid/hardware/Sensor;->getVendor()Ljava/lang/String;

    move-result-object v0

    if-eqz v0, :cond_1

    move v0, v1

    .line 93
    :goto_0
    if-eqz v0, :cond_0

    .line 94
    iget-object v0, p1, Landroid/hardware/SensorEvent;->sensor:Landroid/hardware/Sensor;

    invoke-virtual {v0}, Landroid/hardware/Sensor;->getType()I

    move-result v0

    iget-object v3, p1, Landroid/hardware/SensorEvent;->sensor:Landroid/hardware/Sensor;

    invoke-virtual {v3}, Landroid/hardware/Sensor;->getName()Ljava/lang/String;

    move-result-object v3

    iget-object v4, p1, Landroid/hardware/SensorEvent;->sensor:Landroid/hardware/Sensor;

    .line 95
    invoke-virtual {v4}, Landroid/hardware/Sensor;->getVendor()Ljava/lang/String;

    move-result-object v4

    iget-wide v6, p1, Landroid/hardware/SensorEvent;->timestamp:J

    iget-object v5, p1, Landroid/hardware/SensorEvent;->values:[F

    .line 6108
    invoke-direct {p0, v0, v3, v4}, Lcom/appsflyer/g;->ˎ(ILjava/lang/String;Ljava/lang/String;)Z

    move-result v0

    if-eqz v0, :cond_0

    .line 6146
    invoke-static {}, Ljava/lang/System;->currentTimeMillis()J

    move-result-wide v8

    .line 6147
    iget-object v0, p0, Lcom/appsflyer/g;->ˊ:[[F

    aget-object v0, v0, v2

    .line 6148
    if-nez v0, :cond_2

    .line 6149
    iget-object v0, p0, Lcom/appsflyer/g;->ˊ:[[F

    array-length v1, v5

    invoke-static {v5, v1}, Ljava/util/Arrays;->copyOf([FI)[F

    move-result-object v1

    aput-object v1, v0, v2

    .line 6150
    iget-object v0, p0, Lcom/appsflyer/g;->ॱ:[J

    aput-wide v8, v0, v2

    .line 6165
    :cond_0
    :goto_1
    return-void

    :cond_1
    move v0, v2

    .line 6079
    goto :goto_0

    .line 6152
    :cond_2
    iget-object v2, p0, Lcom/appsflyer/g;->ˊ:[[F

    aget-object v2, v2, v1

    .line 6153
    if-nez v2, :cond_3

    .line 6154
    array-length v2, v5

    invoke-static {v5, v2}, Ljava/util/Arrays;->copyOf([FI)[F

    move-result-object v2

    .line 6155
    iget-object v3, p0, Lcom/appsflyer/g;->ˊ:[[F

    aput-object v2, v3, v1

    .line 6156
    iget-object v3, p0, Lcom/appsflyer/g;->ॱ:[J

    aput-wide v8, v3, v1

    .line 6157
    invoke-static {v0, v2}, Lcom/appsflyer/g;->ˎ([F[F)D

    move-result-wide v0

    iput-wide v0, p0, Lcom/appsflyer/g;->ʽ:D

    goto :goto_1

    .line 6161
    :cond_3
    const-wide/32 v10, 0x2faf080

    iget-wide v12, p0, Lcom/appsflyer/g;->ॱॱ:J

    sub-long v12, v6, v12

    cmp-long v3, v10, v12

    if-gtz v3, :cond_0

    .line 6162
    iput-wide v6, p0, Lcom/appsflyer/g;->ॱॱ:J

    .line 6163
    invoke-static {v2, v5}, Ljava/util/Arrays;->equals([F[F)Z

    move-result v2

    if-eqz v2, :cond_4

    .line 6165
    iget-object v0, p0, Lcom/appsflyer/g;->ॱ:[J

    aput-wide v8, v0, v1

    goto :goto_1

    .line 6167
    :cond_4
    invoke-static {v0, v5}, Lcom/appsflyer/g;->ˎ([F[F)D

    move-result-wide v2

    .line 6168
    iget-wide v6, p0, Lcom/appsflyer/g;->ʽ:D

    cmpl-double v0, v2, v6

    if-lez v0, :cond_0

    .line 6169
    iget-object v0, p0, Lcom/appsflyer/g;->ˊ:[[F

    array-length v4, v5

    invoke-static {v5, v4}, Ljava/util/Arrays;->copyOf([FI)[F

    move-result-object v4

    aput-object v4, v0, v1

    .line 6170
    iget-object v0, p0, Lcom/appsflyer/g;->ॱ:[J

    aput-wide v8, v0, v1

    .line 6171
    iput-wide v2, p0, Lcom/appsflyer/g;->ʽ:D

    goto :goto_1
.end method

.method final ˊ(Ljava/util/Map;)V
    .locals 1
    .param p1    # Ljava/util/Map;
        .annotation build Landroid/support/annotation/NonNull;
        .end annotation
    .end param
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Lcom/appsflyer/g;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;>;)V"
        }
    .end annotation

    .prologue
    .line 120
    const/4 v0, 0x1

    invoke-direct {p0, p1, v0}, Lcom/appsflyer/g;->ॱ(Ljava/util/Map;Z)V

    .line 121
    return-void
.end method

.method public final ˋ(Ljava/util/Map;)V
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Ljava/util/Map",
            "<",
            "Lcom/appsflyer/g;",
            "Ljava/util/Map",
            "<",
            "Ljava/lang/String;",
            "Ljava/lang/Object;",
            ">;>;)V"
        }
    .end annotation

    .prologue
    .line 124
    const/4 v0, 0x0

    invoke-direct {p0, p1, v0}, Lcom/appsflyer/g;->ॱ(Ljava/util/Map;Z)V

    .line 125
    return-void
.end method
